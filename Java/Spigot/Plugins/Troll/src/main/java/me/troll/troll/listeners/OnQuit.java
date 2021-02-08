package me.troll.troll.listeners;

import org.bukkit.ChatColor;
import org.bukkit.event.EventHandler;
import org.bukkit.event.Listener;
import org.bukkit.event.player.PlayerQuitEvent;

import java.util.Locale;

public class OnQuit implements Listener {

    @EventHandler
    void OnQuit(PlayerQuitEvent e) {
        var playerName = e.getPlayer().getDisplayName();
        e.setQuitMessage(ChatColor.RED + "Чао " + ChatColor.DARK_AQUA + playerName);
    }
}
