using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetVideoDetails
{
    internal class TraverseClassAttributes
    {



        public void TestTraverseObject()
        {
            // 创建一个 Person 对象
            Person person = new Person()
            {
                Name = "John Doe",
                Age = 30
            };

            // 遍历 Person 类的所有属性
            Type personType = person.GetType();  // 获取对象类型
            PropertyInfo[] properties = personType.GetProperties();  // 获取所有属性

            foreach (var property in properties)
            {
                // 获取属性名
                string propertyName = property.Name;

                // 获取属性值
                object propertyValue = property.GetValue(person);

                // 打印属性名和值
                Console.WriteLine($"{propertyName}: {propertyValue}");
            }
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
