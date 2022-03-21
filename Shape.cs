
namespace MathApplication
{
    
    public abstract class Shape
    {
        private string shapeName;
        public string ShapeName 
        {
            get
            {
                return shapeName;
            } 
            set
            {
                shapeName = value;
            }
        }        

        private double surfaceArea;
        public double SurfaceArea 
        {
            get
            {
                return surfaceArea;
            } 
            set
            {
                surfaceArea = value;
            }
        }        

        private double perimeter;
        public double Perimeter 
        {
            get
            {
                return perimeter;
            } 
            set
            {
                perimeter = value;
            }
        }        


        public Shape(string shapename)
        {
            this.shapeName = shapename;
        }

        public abstract void printShape();
        

       
    }

    public class Circle : Shape {
        private double radius;


        public Circle(double radius) : base("Circle")
        {         
            this.radius = radius;
            base.Perimeter = (this.radius * 2 * Math.PI);
            base.SurfaceArea = (Math.Pow(this.radius,2) * Math.PI);
        }
        public double Radius 
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            } 
        }

        public override void printShape()
        {
            Console.WriteLine($"{this.ShapeName} Area: {this.SurfaceArea} | Perimeter: {this.Perimeter} | Radius: {this.Radius}");            
        }
      
    }

    public class Triangle : Shape {
        private double triangleSideA;
        private double triangleBase;
        private double triangleSideC;
        private double height;
        

        public Triangle(double sideABC ) : base("Equilateral Triangle")
        {
            this.triangleSideA = sideABC;         
            this.triangleBase = sideABC;
            this.triangleSideC = sideABC;

            this.height = sideABC * Math.Sqrt(3) / 2;
            base.Perimeter = (this.triangleSideA + this.triangleBase + this.triangleSideC);
            base.SurfaceArea = ((this.triangleBase * this.height) / 2);     
        }
        public Triangle(double sideAC, double b ) : base("Isosceles Triangle")
        {
            this.triangleSideA = sideAC;         
            this.triangleBase = b;
            this.triangleSideC = sideAC;
           
            
            base.Perimeter = (this.triangleSideA + this.triangleBase + this.triangleSideC);

            double s = ( (this.triangleSideA+this.triangleBase+this.triangleSideC) / 2);                    
            base.SurfaceArea = (Math.Sqrt(   (s*    (s-this.triangleSideA) * (s-this.triangleBase) * (s-this.triangleSideC))));

            this.height = 2 * (base.SurfaceArea / this.triangleBase);


            
        }        
        public Triangle(double sideA, double sideC, double b ) : base("Scalene Triangle")
        {
            this.triangleSideA = sideA;         
            this.triangleBase = b;
            this.triangleSideC = sideC;
                       
            base.Perimeter = (this.triangleSideA + this.triangleBase + this.triangleSideC);

            double s = ( (this.triangleSideA+this.triangleBase+this.triangleSideC) / 2);                    
            base.SurfaceArea = (Math.Sqrt(   (s*    (s-this.triangleSideA) * (s-this.triangleBase) * (s-this.triangleSideC))));

            this.height = 2 * (base.SurfaceArea / this.triangleBase);

            
        }       

                public Triangle() : base("T")
        {
            
        }       

        public double TriangleSideA
        {
            get
            {
                return triangleSideA;
            }
            set
            {
                triangleSideA = value;
            } 
        }
        public double TriangleBase
        {
            get
            {
                return triangleBase;
            }
            set
            {
                triangleBase = value;
            } 
        }
        public double TriangleSideC
        {
            get
            {
                return triangleSideC;
            }
            set
            {
                triangleSideC = value;
            } 
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            } 
        }

         public override void printShape()
        {
            Console.WriteLine($"{this.ShapeName} Area: {this.SurfaceArea} | Perimeter: {this.Perimeter} | Height: {this.height} | Base: {this.triangleBase} | Side A: {this.triangleSideA} | Side C: {this.triangleSideC}");            
        }       

    }

    public class Quadrilateral : Shape {
        private double length;
        private double width;

        public Quadrilateral() : base("Q")
        {
            
        }      

        public Quadrilateral(double sideSize ) : base("Square")
        {
            this.length = sideSize;         
            this.width = sideSize;
            base.SurfaceArea = (this.length * this.width);
            base.Perimeter =  ( (this.length + this.width) * 2);
        }
        public Quadrilateral(double length, double width ) : base("Rectangle")
        {
            this.length = length;         
            this.width = width;
            base.SurfaceArea = (this.length * this.width);
            base.Perimeter =  ( (this.length + this.width) * 2);
        }        

        

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            } 

        }
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            } 

        }

        public override void printShape()
        {
            Console.WriteLine($"{this.ShapeName} Area: {this.SurfaceArea} | Perimeter: {this.Perimeter} | Length: {this.length} | Width: {this.width}");            
        }
    }

       public class UserCreatedShapes : Shape {
       
        public UserCreatedShapes(string shapesname, double shapesurfacearea, double shapeperimeter) : base(shapesname)
        {            
            base.SurfaceArea = shapesurfacearea;
            base.Perimeter =  shapeperimeter;
        }
        public override void printShape()
        {
            Console.WriteLine($"{this.ShapeName} Area: {this.SurfaceArea} | Perimeter: {this.Perimeter}");            
        }
    }
}