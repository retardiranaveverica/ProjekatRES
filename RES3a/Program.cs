using DumpingBuffer;
﻿using Common;
using DumpingBufferComponent;
using HistoricalComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RES3a
{
    class Program
    {
        static void Main(string[] args)
        {
            WriterToHistorical writerToHistorical = new WriterToHistorical();
            WriterToDumpingBaffer writerToDumpingBaffer = new WriterToDumpingBaffer();
            Database database = new Database();
            DataFromDB data = new DataFromDB();
            DatabaseDB databaseDB = new DatabaseDB();
            while (true)
            {
                Console.WriteLine("Odaberite 1 ili 2");
                Console.WriteLine("1. Slanje preko Dumping Buffer-a");
                Console.WriteLine("2. Slanje direktno na Historical");

                int broj = Int32.Parse(Console.ReadLine());

              //  database.Create();

                switch (broj)
                {

                    case 1:
                        writerToDumpingBaffer.SetDataToDumpingBuffer();
                        data.PackAddData();
                        database.WriteToDatabase();
                      //  databaseDB.WriteToDatabase();
                        break;
                    case 2:
                        writerToHistorical.SettingValues();
                        database.WriteToDatabase();
                        break;
                    default:
                        Console.WriteLine("Izaberite opciju 1 ili 2!");
                        break;
                }

            }
        }
    }
}
