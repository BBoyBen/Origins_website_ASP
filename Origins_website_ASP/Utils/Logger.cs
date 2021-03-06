﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Origins_website_ASP.Utils
{
    public static class Logger
    {
        private static string GetFilePath(string type)
        {
            string filePath = "C:/Users/ben63/Documents/Projet/Logs/LogOrigins/";

            switch (type)
            {
                case "ERROR":
                    filePath += "Error/";
                    break;
                case "INFO":
                    filePath += "Info/";
                    break;
                case "DEBUG":
                    filePath += "Debug/";
                    break;
                default:
                    filePath += "Autres/";
                    break;
            }
            return filePath;
        }

        private static string GetFileName(string type)
        {
            DateTime today = DateTime.Now;

            string fileName = type + "_" + today.Day + today.Month + today.Year + today.Hour + today.Minute + today.Second + ".txt";

            return fileName;
        }

        public static void Log(string type, string message)
        {
            string filePath = GetFilePath(type);
            string fileName = GetFileName(type);

            try
            {
                StreamWriter fichierLog = new StreamWriter(filePath + fileName, false);
                fichierLog.WriteLine(type + " " + DateTime.Now + " : " + message);
                fichierLog.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur ouverture fichier log : " + e);
            }

        }
    }
}