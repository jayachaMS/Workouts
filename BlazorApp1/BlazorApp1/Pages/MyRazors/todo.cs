using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BlazorApp1
{
	public class ToDoClass : ComponentBase
	{
		#region Fields
		protected readonly IList<MyDoTo> todos = new List<MyDoTo>();
		protected string newtodo;
		#endregion

		#region Constructors
		public ToDoClass()
		{
			
		}
		#endregion

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			base.BuildRenderTree(builder);
		}

		#region Privates
		protected void AddNew()
		{
			if(string.IsNullOrEmpty(newtodo)) return;
			todos.Add(new MyDoTo { Title = newtodo });
			newtodo = string.Empty;
		}
		#endregion
	}
}