package me.troll.troll;

import me.troll.troll.Commands.say;
import me.troll.troll.listeners.OnJoin;
import me.troll.troll.listeners.OnQuit;
import org.bukkit.plugin.java.JavaPlugin;

public final class Troll extends JavaPlugin {

    @Override
    public void onEnable() {
        // Plugin startup logic
        getServer().getPluginManager().registerEvents(new OnJoin(), this);
        getServer().getPluginManager().registerEvents(new OnQuit(), this);
        getCommand("test").setExecutor(new say());
    }

    @Override
    public void onDisable() {
        // Plugin shutdown logic
    }
}
