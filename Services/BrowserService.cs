using MauiBlazorHybrid.Models;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorHybrid.Services
{
    public class BrowserService
    {
        private readonly IJSRuntime _js;
        public BrowserService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<ScreenDimension> GetDimensions()
        {
            return await _js.InvokeAsync<ScreenDimension>("getDimensions");
        }
    }
}
