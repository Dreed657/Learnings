package main

import (
	"flag"
	"log"

	"github.com/gofiber/fiber/v2"
	"github.com/gofiber/websocket/v2"
)

type client struct{}

var clients = make(map[*websocket.Conn]client)
var register = make(chan *websocket.Conn)
var broadcast = make(chan string)
var unregister = make(chan *websocket.Conn)

func main() {
	app := fiber.New()

	app.Static("/", "./index.html")

	go runHub()

	app.Get("/ws", websocket.New(func(c *websocket.Conn) {
		defer func() {
			unregister <- c
			c.Close()
		}()

		register <- c

		for {
			messageType, message, err := c.ReadMessage()
			if err != nil {
				if websocket.IsUnexpectedCloseError(err, websocket.CloseGoingAway, websocket.CloseAbnormalClosure) {
					log.Println("read error:", err)
				}
				return
			}

			if messageType == websocket.TextMessage {
				broadcast <- string(message)
			} else {
				log.Println("websocket message received of type", messageType)
			}
		}
	}))

	app.Get("/random", func(ctx *fiber.Ctx) error {
		log.Println("Random")

		return ctx.Status(fiber.StatusOK).JSON(&fiber.Map{
			"status":  fiber.StatusOK,
			"message": "random",
		})
	})

	addr := flag.String("addr", ":8080", "http service address")
	flag.Parse()
	log.Fatal(app.Listen(*addr))
}

func runHub() {
	for {
		select {
		case connction := <-register:
			clients[connction] = client{}
			log.Println("connection registered", connction)

		case message := <-broadcast:
			log.Println("message received:", message)

			for connection := range clients {
				if err := connection.WriteMessage(websocket.TextMessage, []byte(message)); err != nil {
					log.Println("write error:", err)

					connection.WriteMessage(websocket.CloseMessage, []byte{})
					connection.Close()
					delete(clients, connection)
				}
			}

		case connection := <-unregister:
			delete(clients, connection)

			log.Println("connection unregistered")
		}
	}
}
