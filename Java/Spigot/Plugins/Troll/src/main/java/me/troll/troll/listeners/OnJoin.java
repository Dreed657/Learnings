package me.troll.troll.listeners;

import org.bukkit.ChatColor;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerJoinEvent;

import java.util.Locale;

public class OnJoin implements Listener {

    @EventHandler
    void OnJoin(PlayerJoinEvent e) {
        var playerName = e.getPlayer().getDisplayName();
        e.setJoinMessage(ChatColor.GREEN + "Добре дошъл " + ChatColor.GOLD + playerName);
    }
}
