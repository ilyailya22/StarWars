﻿namespace StarWars.iOS;

public static class Application
{
    // This is the main entry point of the application.
    private static void Main(string[] args)
    {
        UIApplication.Main(args, null, typeof(AppDelegate));
    }
}