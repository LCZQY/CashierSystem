using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;

namespace QP.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    } 
}