﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loader;
using OptimizeLib.Model;

namespace TestOptimize
{
	class Program
	{
		static void Main(string[] args)
		{
			// создать задачу по шаблону
			var taskId = ModelLoader.CreateTask(1, "Тестовая задача", 10);
			Console.WriteLine("Создана задача по шаблону: {0}", taskId);
			Console.ReadLine();


			//var task = TotalTask.CreateTestTask();

			//int res = task.GetVehicleCount(4);

			//List<string> lst = new List<string>();
			//for (int i = 1; i < 100; i++)
			//{
			//    //lst.Add($"f({i}) = {task.GetVehicleCount(i)}");

			//    lst.Add($"{i};{task.GetVehicleCount(i)}");
			//}

			//File.WriteAllLines("out.csv", lst);
		}


	}
}
