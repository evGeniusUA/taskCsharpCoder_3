using System;
using System.Numerics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace task1
{
	class Program
	{
		public static void Main(string[] args)
		{
			#region="den"
			string s ="";
			//int rezY=0;
			//string str="";
			//string txt = "";
			int lnght=0;
			//int[]mas=new int[26];
			string buf ="";
			List<String> mas = new List<String>();
			int[,] ms;
			List<int> rezmas = new List<int>();
			string num="";
			s = File.ReadAllText(@"C:\Users\rAbOtA\Downloads\16.data");//( @"C:\Users\rAbOtA\Downloads\16.data");
			//bool tf=false;
			//int rez=0;
			lnght = s.Split(new string [] {"\r"}, StringSplitOptions.None).Length - 1;
			ms = new int[lnght,2];
			
			
			for (int i = 0; i <lnght; i++)
			{
				for (int y = 0; y < s.IndexOf("\r"); y++)
				{
					try{
						if((s[y]+s[y+1]).ToString()!="\r")
							buf += s[y];
					}
					catch{}
				}
				s= s.Remove(0,buf.Length+2);
				num="";
				for (int z = 0; z <buf.IndexOf(" "); z++)
				{
					num+=buf[z];
				}
				
				ms[i,0]  = Convert.ToInt32(num);
				num="";
				try{
					for (int z1 =buf.IndexOf(" ")+1 ; z1 >buf.IndexOf(" "); z1++)
					{
						num+=buf[z1];
					}
				}catch{}
				
				ms[i,1]  = Convert.ToInt32(num);
				buf="";
				
				
			}
			
			#endregion
			#region="jeka"
//			List<MyClass> listResult = new List<MyClass>();
//			MyClass myClass = new MyClass();
//			myClass.listNumber.Add(ms[0,0]);
//			myClass.listNumber.Add(ms[0,1]);
//			listResult.Add(myClass);
//
//			bool fl = false;
//			int tmp = -1;
//			int j=0;
//
//			for (int i = 1; i < 500; i++) {
//				fl = false;
//				for (int k = 0; k <  listResult.Count; k++) {
//					for (int g = 0; g < listResult[k].listNumber.Count; g++) {
//						if (ms[i,j] == listResult[k].listNumber[g] || ms[i,j+1] == listResult[k].listNumber[g]){
//							fl = true;
//							tmp = k;
//
//						}
//					}
//
//				}
//
//				if(fl){
//					listResult[tmp].listNumber.Add(ms[i,j]);
//					listResult[tmp].listNumber.Add(ms[i,j+1]);
//				}else{
//					MyClass m = new MyClass();
//					m.listNumber.Add(ms[i,j]);
//					m.listNumber.Add(ms[i,j+1]);
//					listResult.Add(m);
//				}
//			}
//
//
//
//			int count = 0;
//			for (int i = 0; i <  listResult.Count; i++) {
//				count += listResult[i].listNumber.Count;
//				Console.Write(" #");
//				for (j = 0; j < listResult[i].listNumber.Count; j++) {
//					Console.Write(listResult[i].listNumber[j]+".");
//				}
//				//Console.WriteLine();
//			}
//			Console.WriteLine();
//			Console.Write(listResult.Count);
			//Console.ReadKey();
			#endregion
			
			int[][] arr = new int[2233][];

			for (int i = 0; i < 2233; i++)
			{
				arr[i] = new int[2] { ms[i,0],ms[i,1]};
			}
			
			int j,k,g,b;
			j = 1 ;k = 0; b = g = 0;
			bool fl = true,fl2=true,fl3=true;
			do{
				do{
					do{
						if(arr[g][b]== arr[j][k] && arr[g][b] != 0){
							Array.Resize<int>(ref arr[g], arr[g].Length+2);
							arr[g][arr[g].Length-2] = arr[j][0];
							arr[g][arr[g].Length-1] = arr[j][1];
							arr[j][0]=arr[j][1]=0;
						}
						
						if(k==1)j++;
						if(j>2232){fl=false; break;}
						if(k==1){k--; continue;}
						if(k==0)k++;
					}while(fl);
					if(b < arr[g].Length-1){
						b++;j=0;fl=true;
					}else{fl2=false;}
				}while(fl2);
				if(g < 2232){b=0;g++;j=0;fl2=true;}
				else{fl3=false;}
			}while(fl3);
			
			fl=true;b=2;int sum = 0;
			for (int i = 0; i < 2233; i++){
				//Console.Write(" # "+arr[i][0]+" "+arr[i][1]);
				do{
					
					
					if(b < arr[i].Length-1){
						b++;j=0;fl=true;Console.Write(" "+arr[i][b]);
					}else{fl=false;
						if(b>2){Console.WriteLine("\r\n"); 
							sum++;}
					}
				}while(fl);
				b=2;
			}
			
			//Array.Resize<int>(ref arr[1], 0);
			
			
			System.Console.WriteLine("Press any key to exit." + sum);
			System.Console.ReadKey();

		}
	}

	
	class MyClass
	{
		public List<int> listNumber = new List<int>();
	}
}