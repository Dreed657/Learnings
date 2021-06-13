package main

import "math"

type Shape interface {
	Area() float64
}

type Rectangle struct {
	Width  float64
	Height float64
}

func (r Rectangle) Area() float64 {
	return r.Width * r.Height
}

type Circle struct {
	Radius float64
}

func (c Circle) Area() float64 {
	return math.Pi * c.Radius * c.Radius
}

func Perimeter(r Rectangle) float64 {
	return 2 * (r.Width + r.Height)
}

// func main() {
// 	rectangle := Rectangle{12.0, 6.0}
// 	area := Area(rectangle)
// 	fmt.Printf("Area: %s", area)
// }
