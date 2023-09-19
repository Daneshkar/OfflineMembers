using System.ComponentModel;
using System.Reflection;
using System.Threading.Channels;

namespace Delegates
{
	internal class Program
	{
		//delegate returnType name(parameters)
		delegate int CalcDel(int x, int y);
		delegate void PrintDel(string s);
		//do the same as Action key word
		delegate void ActionDel<T1>(T1 x);
		//do the same as Func key word
		delegate TResult FuncDel<in T1,in T2,out TResult>(T1 x,T2 y);

		static void Main(string[] args)
		{
			//CalcDel sum = new CalcDel(Sum);
			//shorter version of above code:
			CalcDel sum = Sum;
			//int r = sum.Invoke(2, 3);
			//shorter version of above code:
			int r = sum(2, 3);
			Console.WriteLine($"the result is:{r}");
			//----------------------------------
			PrintDel? strPrint = Print1;
			strPrint += Print2;
			strPrint("two method assigned");
			strPrint -= Print1;
			if(strPrint != null)
				strPrint("one method assigned");
			//------------------------------------
			Action<string> printAction = Print1;
			//same as:
			ActionDel<string> printDel = Print2;

			//in FUnc the last generic parameter is always the return type
			Func<int, int, int> sumFunc = Sum;
			//same as:
			FuncDel<int, int, int> sumDel = Sum;
			//--------------------------------------
			printCalc(2, 3, Sum);
			printCalc(2, 3, Multi);
			//can write method inside parameters
			printCalc(4,5,(int x,int y) => x + y);

			//this shows the method assigned to variable
			Console.WriteLine(sum.Method);

		}
		static int Sum(int x, int y) => x + y;
		static int Multi(int x, int y) => x * y;
		static void Print1(string s) => Console.WriteLine($"The First Print Method: {s}");
		static void Print2(string s) => Console.WriteLine($"The Second Print Method: {s}");
		static void printCalc(int x, int y, CalcDel m) => Console.WriteLine(m(x, y));
	}
}