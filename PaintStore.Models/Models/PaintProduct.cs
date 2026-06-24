using System;

namespace PaintStore.Models.Models;

public class PaintProduct
{
    public const float TaxRate = 0.1f;  // ------> 我将该field设置为"Constant"常量，就不需要{get; set;}了。 常量一般用于定义一个固定不变的值
    const float DefaultDiscount = 0.95f;
    public string Name { get; private set; }
    public PaintTypes Type { get; set; }
    public PaintSpecification Specification { get; set; }
    public decimal Price { get; set; }
}
