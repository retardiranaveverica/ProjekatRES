<<<<<<< HEAD
﻿using DumpingBuffer;
=======
﻿using Common;
>>>>>>> 44fcbd61c892efcfc3e7785c298693939754e6a4
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
            while (true)
            {
                Console.WriteLine("Odaberite 1 ili 2");
                Console.WriteLine("1. Slanje preko Dumping Buffer-a");
                Console.WriteLine("2. Slanje direktno na Historical");

                int broj = Int32.Parse(Console.ReadLine());
<<<<<<< HEAD
                database.Create();
=======

>>>>>>> 44fcbd61c892efcfc3e7785c298693939754e6a4
                switch (broj)
                {

                    case 1:
                        writerToDumpingBaffer.SetDataToDumpingBuffer();
                        data.PackAddData();
<<<<<<< HEAD
=======
                        database.WriteToDatabase();
>>>>>>> 44fcbd61c892efcfc3e7785c298693939754e6a4
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
