
class Program
{
	//event-based asynchronous pattern
	static BackgroundWorker _bw = new BackgroundWorker();
	static void Main()
	{
		_bw.DoWork += bw_DoWork;
		_bw.RunWorkerAsync("Message to worker");
		Console.ReadLine();
	}

	static void bw_DoWork(object sender, DoWorkEventArgs e)
	{
		Console.WriteLine(e.Argument);
		//will output "Message to worker"
	}
}
