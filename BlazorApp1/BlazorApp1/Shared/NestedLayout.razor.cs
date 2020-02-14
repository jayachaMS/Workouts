using System.Threading.Tasks;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1
{
	[LayoutAttribute(typeof(RootLayout))]
	public class NestedLayout1 : LayoutComponentBase
	{
		#region Properties
		[Parameter]
		public string LayoutParam { get; set; }

		public string Param { get; set; }
		#endregion

		#region Protecteds
		protected override void OnInitialized()
		{
			base.OnInitialized();
			this.Param = "Hi";
		}

		//public override Task SetParametersAsync(ParameterView parameters)
		//{
		//	object LayoutParam = null;
		//	if((this.Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("LayoutParam", out LayoutParam) == true)
		//	{
		//		LayoutParam = LayoutParam?.ToString();
		//		this.Param = this.LayoutParam;
		//	}

		//	return base.SetParametersAsync(parameters);
		//}

		protected override void OnParametersSet()
		{
			object LayoutParam = null;
			if((this.Body.Target as RouteView)?.RouteData.RouteValues?.TryGetValue("LayoutParam", out LayoutParam) == true)
			{
				LayoutParam = LayoutParam?.ToString();
				this.Param = this.LayoutParam;
			}
		}

		protected override void OnAfterRender(bool firstRender)
		{
			base.OnAfterRender(firstRender);
			StateHasChanged();
		}
		#endregion
	}
}