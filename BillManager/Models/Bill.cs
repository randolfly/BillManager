using BootstrapBlazor.Components;

namespace BillManager.Models;

using System.ComponentModel.DataAnnotations;

public class Bill
{
    [AutoGenerateColumn(Ignore = true)] public int Id { get; set; }

    [Required(ErrorMessage = "请选择时间")]
    [Display(Name = "日期")]
    [AutoGenerateColumn(Order = 1, FormatString = "yyyy-MM-dd", Width = 180)]
    public DateTime DateTime { get; set; }

    [Required(ErrorMessage = "{0}不能为空")]
    [Display(Name = "简介")]
    [AutoGenerateColumn(Order = 10)]
    public string Brief { get; set; } = String.Empty;

    [Required(ErrorMessage = "账单主体不能为空")]
    [Display(Name = "人员")]
    [AutoGenerateColumn(Order = 20)]
    public Person Person { get; set; }

    [Required(ErrorMessage = "{0}不能为空")]
    [Display(Name = "价格")]
    [AutoGenerateColumn(Order = 30)]
    public decimal Price { get; set; }

    [Display(Name = "详细介绍")]
    [AutoGenerateColumn(Order = 100)]
    public string Detail { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0}不能为空")]
    [Display(Name = "状态")]
    [AutoGenerateColumn(Order = 50)]
    public BillState BillState { get; set; }

    [Required(ErrorMessage = "需要指定是否可报销")]
    [Display(Name = "可报销否")]
    [AutoGenerateColumn(Order = 60)]
    public RbsType RbsType { get; set; }

    [Required(ErrorMessage = "{0}不能为空")]
    [Display(Name = "订单类型")]
    [AutoGenerateColumn(Order = 70)]
    public BillType BillType { get; set; }

    [Display(Name = "订单附件")]
    [AutoGenerateColumn(Order = 1000)]
    public List<Asset?> Assets { get; set; } = new();
}

// 显示订单是否被报销
public enum RbsType
{
    可报销,
    不可报销
}

public enum BillState
{
    完成,
    未完成
}

public enum BillType
{
    食品,
    娱乐,
    器材,
    软件,
    出行,
    转账,
    杂项
}

public enum Person
{
    实验室,
    唐晓强,
    季益中,
    康珊珊,
    侯森浩,
    李国通,
    李东兴,
    王禹衡,
    张荣侨,
    李政清,
    武昊,
    未央班学生,
    其余人员
}