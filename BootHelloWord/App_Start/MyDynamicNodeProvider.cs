using BootHelloWord.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootHelloWord
{
    public class MyDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodes)
        {
            var returnValue = new List<DynamicNode>();

            //using (var uow = new MyDbContext())
            //{

            //    // 取出此用戶角色關聯的所有Menu項
            //    var loginUserId = "Foo";
            //    var roleMenus = uow.Users.Where(u => u.UserId == loginUserId)
            //                        .SelectMany(p => p.Roles)
            //                        .SelectMany(r => r.Menus)
            //                        .Distinct();


            foreach (var menu in Menus)
            {

                DynamicNode node = new DynamicNode()
                {
                    // 顯示的文字
                    Title = menu.Name,
                    // 父Menu項目Id
                    ParentKey = menu.ParentId.HasValue ? menu.ParentId.Value.ToString() : "",
                    // Node Key
                    Key = menu.MenuId.ToString(),
                    // Action Name
                    Action = menu.Action,
                    // Controller Name
                    Controller = menu.Controller,
                    // Url (只要有值就會以此為主)
                    Url = menu.Url
                };

                if (!string.IsNullOrWhiteSpace(menu.RouteValues))
                {
                    // 此部分利用menu.RouteValues欄位文字轉乘key-value pair
                    // 當作RouteValues使用
                    // ex. Key1=value1,Key2=value2...
                    node.RouteValues = menu.RouteValues.Split(',').Select(value => value.Split('='))
                                            .ToDictionary(pair => pair[0], pair => (object)pair[1]);
                }

                returnValue.Add(node);
                //    }
            }
            return returnValue;
        }

        private static List<Menu> Menus
        {
            get
            {
                return new List<Menu>()
                {
                    new Menu() {  MenuId=1, Name="聯絡人管理",Action="Index",Controller="Contact"},
                    new Menu() {  MenuId=2, Name="A"},
                    new Menu() {  MenuId=3, Name="C" },

                    new Menu() {  MenuId=31 ,ParentId=3, Name="聯絡人管理",Action="Index",Controller="Contact"},
                    new Menu() {  MenuId=32, Name="C2" ,ParentId=3},
                    new Menu() {  MenuId=33, Name="C3",ParentId=3 }
                };

            }
        }

        DynamicNode MakeNode(string title, string parentKey, string key, string action, string controller, string url, string routeValues)
        {
            DynamicNode result = new DynamicNode()
            {
                // 顯示的文字
                Title = title,
                // 父Menu項目Id
                ParentKey = parentKey,
                // Node Key
                Key = key,
                // Action Name
                Action = action,
                // Controller Name
                Controller = controller,
                // Url (只要有值就會以此為主)
                Url = url
            };

            if (!string.IsNullOrWhiteSpace(routeValues))
            {
                // 此部分利用menu.RouteValues欄位文字轉乘key-value pair
                // 當作RouteValues使用
                // ex. Key1=value1,Key2=value2...
                result.RouteValues = routeValues.Split(',').Select(value => value.Split('='))
                                        .ToDictionary(pair => pair[0], pair => (object)pair[1]);
            }
            return result;
        }
    }
}