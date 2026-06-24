using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaintStore.API.Controllers
{
    //localhost:5151/api/PaintProducts  -----> 要严格说明用于那个
    // 通过HTTP verb/method 说明这个请求具体去哪个controller的方法

    //localhost:5151/api/paintproducts/GetAllPaintProductByType/1 GET

    // JSON format key-value pairs
    // {
    //     "Name" : "paint"
    //     "Price" : 100.00
    // }

    [Route("api/[controller]")]   //--------> [controller] 是占位符需要替换掉
    // [ApiController]
    public class PaintProductsController : ControllerBase //------> 里面肯定要有方法来实现分发功能  "ControllerBase"是用来说明这个PaintProductsController是执行的HTTP request
    {
        [HttpPost]   //--------> 这是一个标志，说明POST这回request要到这里来
        // Model Binding ---> c# class <----> json data
        // 需要 属性名字和参数数据类型都匹配
        // url/query?x=11&y=2 ------->QueryString x(想要传进来的参数1号) 11, y(想要传进来的参数1号) 2    非常适合用于前端有filter 或者说 需要分页（Pagination）的情况
        public void CreatePaintProduct([FromBody] PaintProduct paint)     // ----->[FromBody] 将传进来的JSON文件中的内容自动匹配了 PaintProduct 的class类型
        {
            
        }   

        [HttpDelete]
        public void DeletePaintProduct() { }     // ------> 这个method就是一个endpoint

        [HttpGet]
        public void GetPaintProduct() { }

        [HttpGet("GetAllPaintProductByType/{paintType:int}")] //------> 括号中的内容是进一步的匹配机制
        public void GetAllPaintProductByType(int paintType)
        {
            PaintType type = (PaintType)paintType;
        }
    }
}
