using System;

namespace HwStackandQueue
{// ยอมแพ้
 // ใส่ได้แค่ AP ตัวเดียว TwT
    class Node {
        public Char Instruction;
        public Char Data;
        public Node Next;

        public Node(char instructionValue, char dataValue) 
        {
            Instruction = instructionValue;
            Data = dataValue;
        }
    }
    class Queue {
        private Node Root;

        public void Push(Node node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node ptr = Root;
                while (ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = node;
            }
        }

        public void Clear()
        {
            Root = null;
        }

        public bool CheckNodeIsDuplicate(Node node)
        {
            while (Root != null)
            {
                if (Root == node)
                {
                    return true;
                }
                Root = Root.Next;
            }
            return false;
        }

        public Node GetNode()
        {
            if (Root == null)
            {
                return null;
            }
            Node node = Root;
            return node;
        }

        public int CountNode()
        {
            int count = 0;
            while (Root != null)
            {
                Root = Root.Next;
                count++;
            }
            return count;
        }
        public Node Pop() 
        {
            if (Root == null) 
            {
                return null;
            }
            Node node = Root;
            Root = Root.Next;
            node.Next = null;
            return node;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue MainList = new Queue();
            Queue TempList = new Queue();

            while (true) 
            {
                char Instruction = char.Parse(Console.ReadLine());
                if (Instruction == '?')
                {
                    break;
                }
                char Data = char.Parse(Console.ReadLine());
                Node Input = new Node(Instruction, Data);
                MainList.Push(Input);
                Console.WriteLine("");
            }


            Queue CPU_1 = new Queue();
            Queue CPU_2 = new Queue();
            Queue CPU_3 = new Queue();
            Queue CPU_4 = new Queue();
            int CyclesCount = 0;


            while (true)
            {
               
                Node InstructionAndQueueInput = MainList.Pop();

                if (InstructionAndQueueInput == null)
                {
                    //Console.WriteLine(CPU_1.GetNode().Instruction);
                    //Console.WriteLine(CPU_1.GetNode().Data);

                    CPU_1.Clear();
                    CPU_2.Clear();
                    CPU_3.Clear();
                    CPU_4.Clear();
                    CyclesCount++;
                    
                    break;
                }
                else if (CPU_1.CountNode() == 0)
                {
                    CPU_1.Push(InstructionAndQueueInput);
                    //Console.WriteLine(CPU_1.GetNode().Instruction);
                    //Console.WriteLine(CPU_1.GetNode().Data);
                }
                else if (CPU_1.GetNode().Instruction == InstructionAndQueueInput.Instruction) // CPU_1.GetNode().Instruction return null ?
                {
                    int count = CPU_1.CountNode();
                    if (count > 3)
                    {
                        TempList.Push(InstructionAndQueueInput);
                        MainList.Push(TempList.Pop());

                    }
                    else
                    {
                        if (CPU_1.CheckNodeIsDuplicate(InstructionAndQueueInput))
                        {

                        }
                        else
                        {
                            CPU_1.Push(InstructionAndQueueInput);
                        }
                    }
                }
                else if (CPU_2.CountNode() == 0)
                {
                    CPU_2.Push(InstructionAndQueueInput);
                }
                else if (CPU_2.GetNode().Instruction == InstructionAndQueueInput.Instruction)
                {
                    int count = CPU_2.CountNode();
                    if (count > 3)
                    {
                        TempList.Push(InstructionAndQueueInput);
                        MainList.Push(TempList.Pop());

                    }
                    else
                    {
                        if (CPU_2.CheckNodeIsDuplicate(InstructionAndQueueInput))
                        {

                        }
                        else
                        {
                            CPU_2.Push(InstructionAndQueueInput);
                        }
                    }
                }
                else if (CPU_3.CountNode() == 0)
                {
                    CPU_3.Push(InstructionAndQueueInput);
                }
                else if (CPU_3.GetNode().Instruction == InstructionAndQueueInput.Instruction)
                {
                    int count = CPU_3.CountNode();
                    if (count > 3)
                    {
                        TempList.Push(InstructionAndQueueInput);
                        MainList.Push(TempList.Pop());

                    }
                    else
                    {
                        if (CPU_3.CheckNodeIsDuplicate(InstructionAndQueueInput))
                        {

                        }
                        else
                        {
                            CPU_3.Push(InstructionAndQueueInput);
                        }
                    }
                }
                else if (CPU_4.CountNode() == 0)
                {
                    CPU_4.Push(InstructionAndQueueInput);
                }
                else if (CPU_4.GetNode().Instruction == InstructionAndQueueInput.Instruction)
                {
                    int count = CPU_4.CountNode();
                    if (count > 3)
                    {
                        TempList.Push(InstructionAndQueueInput);
                        MainList.Push(TempList.Pop());

                    }
                    else
                    {
                        if (CPU_4.CheckNodeIsDuplicate(InstructionAndQueueInput))
                        {

                        }
                        else
                        {
                            CPU_4.Push(InstructionAndQueueInput);
                        }
                    }
                }
                else if (InstructionAndQueueInput.Instruction != CPU_1.GetNode().Instruction
                || InstructionAndQueueInput.Instruction != CPU_2.GetNode().Instruction
                || InstructionAndQueueInput.Instruction != CPU_3.GetNode().Instruction
                || InstructionAndQueueInput.Instruction != CPU_4.GetNode().Instruction)
                {
                    CPU_1.Clear();
                    CPU_2.Clear();
                    CPU_3.Clear();
                    CPU_4.Clear();
                    TempList.Push(InstructionAndQueueInput);
                    MainList.Push(TempList.Pop());
                    CyclesCount++;
                }
            }

            Console.WriteLine("CPU cycles needed : {0}",CyclesCount);
        }
    }
}
