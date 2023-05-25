namespace OilWellsWebApiTask.Models
{
	public class ResponseService<T>
	{
		public T Data { get; set; }
		public bool IsSuccess { get; set; } = true;
		public string ErrorMessage { get; set; }
	}
}