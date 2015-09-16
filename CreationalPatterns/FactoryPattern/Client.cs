using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    interface IShape
    {
        void Draw();
    }


    class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Ok, Circle is ready.");
        }
    }
    class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Ok, Rectangle is ready.");
        }
    }
    class Triangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Ok, Triangle is ready.");
        }
    }
    class Ellipse : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Ok, Ellipse is ready.");
        }
    }
    class ShapeFactory
    {
        public IShape Create(string key)
        {

            switch (key)
            {
                case "Rectangle":
                    return new Rectangle();
                case "Circle":
                    return new Circle();
                case "Triangle":
                    return new Triangle();
                case "Ellipse":
                    return new Ellipse();
                default:
                    return null;
            }

        }
    }
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of shape that you want to draw it");
            string type = Console.ReadLine();
            ShapeFactory factory = new ShapeFactory();
            IShape shape = factory.Create(type);
            shape.Draw();
            Console.Read();

        }
    }
}
