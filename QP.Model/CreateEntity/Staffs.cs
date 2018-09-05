using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;

namespace QP.Cashier_Model.CreateEntity
{
    /// <summary>
    /// //员工表
    /// </summary>    


    public enum enunSex
    {
        [Display(Name = "男")]
        Boys,
        [Display(Name = "女")]
        Girls
    }


    public enum enumBirthType
    {
        [Display(Name = "农历")]
        N,
        [Display(Name = "新历")]
        X
    }


    public class Staffs
    {   //EmailAddress 判断邮箱格式是否正确

        /// <summary>
        /// //员工ID
        /// </summary>
        [ReadOnly(true)]
        public string StaffID { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        [DisplayName("姓名")]
        [Required(ErrorMessage = "请填写信息")]
        [StringLength(6, MinimumLength = 2, ErrorMessage = "用户名的长度应该在2到6位之间")]
        [RegularExpression("^[\\u4E00-\\u9FA5\\uF900-\\uFA2D]+$", ErrorMessage = "姓名必须为中文")] //正则表达式
        public string StaffName { get; set; }

        /// <summary>
        /// 员工性别
        /// </summary>
        [DisplayName("性别")]
        [Required(ErrorMessage = "请填写信息")]
        public string StaffSex { get; set; } 

        /// <summary>
        /// //default 'N'//生日类型 G:公厉 ,N :农历
        /// </summary>
        [DisplayName("生日类型")]
        [Required(ErrorMessage = "请填写信息")]
        public string StaffBirthType { get; set; }

        /// <summary>
        /// //生日
        /// </summary>
        [DisplayName("生日")]
        [Required(ErrorMessage = "请选择")]
        [DataType(DataType.Date)]
        public DateTime? StaffBirth { get; set; }

        
        /// <summary>
        /// //身份证
        /// </summary>
        [DisplayName("身份证")]
        [Required(ErrorMessage = "请填写信息")]
        [StringLength(19,MinimumLength =18,ErrorMessage ="身份证长度不合法")]
        [RegularExpression(@"\d{17}[\d|x]|\d{15}", ErrorMessage = "身份证号码格式错误")]
        public string StaffIdentity { get; set; }
        
        /// <summary>
        /// 手机号
        /// </summary>
        [DisplayName("手机")]
        [Phone(ErrorMessage ="手机号码格式不正确")]
        [Required(ErrorMessage = "请填写信息")]
        public string StaffPhone { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [DisplayName("工号")]
        [Required(ErrorMessage = "请填写信息")]       
        [MaxLength(10, ErrorMessage = " 用户名输入过长")]
        [Remote(action: "UserExist", controller: "Teoria")]
        public string JobNumber { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [Required(ErrorMessage = "请填写信息")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        /// <summary>
        /// 是否跨店
        /// </summary>
        [DisplayName("是否跨店")]
        [Required(ErrorMessage = "请填写信息")]
        public bool AcrossTheStore { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [DisplayName("职位")]        
        [Required(ErrorMessage = "请填写信息")]
        public string StaffDuty { get; set; }
        
        /// <summary>
        /// 入职时间
        /// </summary>
        [DisplayName("入职时间")]
        [Required(ErrorMessage = "请选择")]
        [DataType(DataType.Date)]
        public DateTime StaffEntryTime { get; set; }
        
        /// <summary>
        /// 所属门店ID
        /// </summary>
        [DisplayName("所属门店")]
        public string ShopID { get; set; }

        
        //// <summary>
        /// 操作ID	
        /// </summary>
        [ReadOnly(true)]
        public string OperationID { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>        
        [ReadOnly(true)]
        public string Roleds { get; set; }


        /// <summary>
        /// 工资表ID
        /// </summary>
        [ReadOnly(true)]
        public string WagesID { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>        
        [ReadOnly(true)]
        public string AuthorityID { get; set; }

        //public virtual List<Wages> Wages { get; set; }
        //public virtual List<Shops> Shops { get; set; }
        //public virtual List<Operation> Operations { get; set; }
        //public virtual List<Authoritys> Authoritys { get; set; }
    }


}
