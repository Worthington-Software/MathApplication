using System.Reflection;
using System.Text.Json;


namespace MathApplication
{
    class Program
    {
        public static List<UserCreatedShapes> listOfUserCreatedShapes = new List<UserCreatedShapes>();
        public static List<Circle> listOfCircles = new List<Circle>();
        public static List<Triangle> listOfTriangles = new List<Triangle>();
        public static List<Quadrilateral> listOfQuadrilaterals = new List<Quadrilateral>();

        
        static void Main(string[] args)
        {
            programDriver();
        }

        public static void programDriver()
        {
            //Create shapes
            listOfCircles.Add(new Circle(5));

            listOfTriangles.Add(new Triangle(4));
            listOfTriangles.Add(new Triangle(3,4));
            listOfTriangles.Add(new Triangle(4,6,9));

            listOfQuadrilaterals.Add(new Quadrilateral(4,8));
            listOfQuadrilaterals.Add(new Quadrilateral(7));

            //Create users list of shapes
            //listOfUserCreatedShapes
            createUserShapes();

            //Print all shapes before sorting
            printShapeList();

            //Sort all shapes
            sortShapeListBy("Perimeter",ref listOfUserCreatedShapes);

            //Print all shapes after sorting
            printShapeList();

            //Get count of a particular shape
            string shapeToLookUp = "Triangle";
            int countOfShapeToLookUp = getShapeCountByType("shapeToLookUp");
            Console.WriteLine($"The number of {shapeToLookUp} is: {countOfShapeToLookUp}");

            //Save user created data using prefixed filename
            Console.WriteLine("Saving...");
            string filename = "jsontxt-";
            saveData(filename);

            //Reset data to test load.
            listOfUserCreatedShapes = new List<UserCreatedShapes>();
            listOfCircles = new List<Circle>();
            listOfTriangles = new List<Triangle>();
            listOfQuadrilaterals = new List<Quadrilateral>();

            //Load data
            Console.WriteLine("Loading...");
            loadData(filename);
            
            //Print all shapes after loading data
            printShapeList();

        }

        public static void createUserShapes()
        {
            foreach (Circle circle in listOfCircles)
            {
                listOfUserCreatedShapes.Add(new UserCreatedShapes(circle.ShapeName, circle.SurfaceArea, circle.Perimeter));
            }
            foreach (Triangle triangle in listOfTriangles)
            {
                listOfUserCreatedShapes.Add(new UserCreatedShapes(triangle.ShapeName, triangle.SurfaceArea, triangle.Perimeter));
            }
            foreach (Quadrilateral quadrilateral in listOfQuadrilaterals)
            {
                listOfUserCreatedShapes.Add(new UserCreatedShapes(quadrilateral.ShapeName, quadrilateral.SurfaceArea, quadrilateral.Perimeter));
            }
        }

        public static void printShapeList()
        {
            if (listOfUserCreatedShapes.Count > 0)
            {
                foreach (UserCreatedShapes userCreatedShapes in listOfUserCreatedShapes)
                {
                    userCreatedShapes.printShape();
                }
            }
        }
        public static void sortShapeListBy(String sortB, ref List<UserCreatedShapes> incomingList)
        {
             switch (sortB)
            {
                case "SurfaceArea":
                    incomingList.Sort((x,y) => x.SurfaceArea.CompareTo(y.SurfaceArea));
                    break;                    
                default:
                    incomingList.Sort((x,y) => x.Perimeter.CompareTo(y.Perimeter));
                    break;    
            }
        }

        public static int getShapeCountByType(String shapeType)
        {
            switch(shapeType)
            {
                case "Circle":
                    return listOfCircles.Count;
                case "Triangle":
                    return listOfTriangles.Count;
                case "Quadrilateral":
                    return listOfQuadrilaterals.Count;
                case "Shape":
                    return listOfUserCreatedShapes.Count;
                default:
                    return 0;
            }
        }

        public static void saveData(String fileName)
        {   
            string jsonSerial = JsonSerializer.Serialize<List<Circle>>(listOfCircles);
            File.WriteAllText(fileName+"Circle.json",jsonSerial);

            jsonSerial = JsonSerializer.Serialize<List<Triangle>>(listOfTriangles);
            File.WriteAllText(fileName+"Triangle.json",jsonSerial);

            jsonSerial = JsonSerializer.Serialize<List<Quadrilateral>>(listOfQuadrilaterals);
            File.WriteAllText(fileName+"Quadrilateral.json",jsonSerial);
        }

        public static void loadData(String fileName)
        {               
            string jsonText = File.ReadAllText(fileName+"Circle.json");
            if (jsonText != null)
            {
                listOfCircles = JsonSerializer.Deserialize<List<Circle>>(jsonText);
            }

            jsonText = File.ReadAllText(fileName+"Triangle.json");
            if (jsonText != null)
            {            
                listOfTriangles = JsonSerializer.Deserialize<List<Triangle>>(jsonText);
            }

            jsonText = File.ReadAllText(fileName+"Quadrilateral.json");
            if (jsonText != null)
            {
            listOfQuadrilaterals = JsonSerializer.Deserialize<List<Quadrilateral>>(jsonText);
            }

            //Create users list of shapes
            //listOfUserCreatedShapes
            createUserShapes();
        }

        
    }
}
