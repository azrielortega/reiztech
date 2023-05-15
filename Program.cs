using System;

namespace reiztechproject{
    class Program{

        static int maxDepth(Branch node){
            // if current node is null
            if(node == null){
                return 0;
            }

            // get all branches
            List<Branch>? branches = node.branches;

            int max = 0;
            if (branches != null){
                foreach (var branch in branches){
                    int depth = maxDepth(branch);

                    // if depth retrieved is higher than max;
                    if (depth > max) max = depth;
                }
            }

            return max + 1;
        }

        static void PrintPreOrderTree(Branch node){
            if( node == null) return;

            Console.Write("{0} ", node.data);

            // get all branches
            List<Branch>? branches = node.branches;

            if (branches != null){
                foreach (var branch in branches){
                    PrintPreOrderTree(branch);
                }
            }
        }

        static void CalculateAngle(){
            // get time input in military format
            Console.Write("Enter time (in military format) : ");
            string? timeString = Console.ReadLine();

            if (TimeSpan.TryParse(timeString, out var dummyOutput) && timeString != null){
                // get hour and minutes by splitting the string
                string[] handList = timeString.Split(":");

                // compute for the angle, formula is = |(30 * H) - (11/2 * M)|, where H is hour and M is minutes
                double hour = Double.Parse(handList[0]);
                double min = Double.Parse(handList[1]);

                if (hour > 12) hour -= 12;

                hour = 30.0 * hour;
                min = (11.0/2.0) * min;

                double angle = Math.Abs(hour - min);

                Console.WriteLine("Initial Angle is {0}", angle);

                // if angle computed is the larger angle
                if (angle == 360){
                    angle = 0;
                }else if (angle > 180){
                    angle = 360 - angle;
                }

                Console.WriteLine("Angle is {0} degrees", angle);
            }
            else{
                Console.WriteLine("Invalid Time Format");
            }
        }

        static void Main(string[] args){
            Console.WriteLine("[1] Calculate Angle of hands of a clock");
            Console.WriteLine("[2] Get the depth of a tree");
            Console.Write("Choose an option: ");

            string? input = Console.ReadLine();

            bool res = int.TryParse(input, out int option);
            if (!res) {
                Console.WriteLine("Invalid Input");
                return;
            }

            if (option == 1) CalculateAngle();
            else if (option == 2) {
                // Create Tree based on sample figure given in specs
                Branch root = new Branch(1);
                
                Branch child1 = new Branch(2);
                Branch child2 = new Branch(3);

                root.addBranch(child1);
                root.addBranch(child2);

                Branch child3 = new Branch(4);
                child1.addBranch(child3);

                Branch child4 = new Branch(5);
                Branch child5 = new Branch(6);
                Branch child6 = new Branch(7);

                child2.addBranch(child4);
                child2.addBranch(child5);
                child2.addBranch(child6);

                Branch child7 = new Branch(8);
                child4.addBranch(child7);

                Branch child8 = new Branch(9);
                Branch child9 = new Branch(10);
                child5.addBranch(child8);
                child5.addBranch(child9);

                Branch child10 = new Branch(11);
                child8.addBranch(child10);

                PrintPreOrderTree(root);
                int depth = maxDepth(root);

                Console.WriteLine("\nDepth of Tree is {0}", depth);

            }
            else{
                Console.WriteLine("Invalid Option");
            }
        }
    }

    public class Branch{
        // added data constructor for visualization of tree
        public int data;
        public List<Branch>? branches;

        //create method
        public Branch(int data){
            this.data = data;
            branches = new List<Branch>();
        }

        // add branch method
        public void addBranch(Branch newBranch){
            this.branches.Add(newBranch);
        }
    }
}

