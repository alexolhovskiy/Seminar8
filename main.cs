/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.


Alex Olhovskiy
*******************************************************************************/
using System;
class HelloWorld
{
  static void Main ()
  {
    //54 Rows sorting
    Console.WriteLine("#54 Rows sorting");
    
    int[,]arr=MakeArr_int(ArrQuery());
    PrintMatrix(arr);
    SortArrRow(arr);
    PrintMatrix(arr);
    MyClear();
    
    //56 Finding row with smallest value
    Console.WriteLine("#56 Finding row with smallest value");
    
    PrintMatrix(arr);
    Console.WriteLine($"Smallest row is #{SmallestRow(arr)}");
    MyClear();
    
    //58 Matrix multiplication
    Console.WriteLine("#58 Matrix multiplication");
    
    int[,]matrix1=MakeArr_int(ArrQuery());
    Console.WriteLine("Note! rows of matrix2 must be equil columns of matrix1");
    int[,]matrix2=MakeArr_int(ArrQuery());
    PrintTwoMatrix(matrix1,matrix2);
    PrintMatrixFormat(MatrixProduct(matrix1,matrix2));
    MyClear();
    
    //60 Formation of a three-dimensional array
    Console.WriteLine("#60 Formation of a three-dimensional array");
    
    Print3DMatrix(ThreeDimentionArr(ArrQuery(true)));
    MyClear();
    
    //62 Spiral array filling
    Console.WriteLine("#62 Spiral array filling");
    
    PrintMatrixFormat(HelicalFilling(ArrQuery(false)));
    MyClear();
    
    //62 Spiral array filling (second option)
    Console.WriteLine("#62 Spiral array filling (second option)");
    
    PrintMatrixFormat(HelicalFilling2(ArrQuery(false)));
    MyClear();
    
  }
  
  public static int[,]HelicalFilling2(int[]param)
  {
    int [,]arr=new int[param[0],param[1]];
      
    int arr_length=param[0]*param[1];
    int count=0;

    int w_start=0;
    int w_finish=param[1]-1;
      
    int h_start=1;
    int h_finish=param[0]-1;
      
    int i=0;
    int j=-1;
    int key=0;
    while(count<arr_length)
    {
        switch(key)
        {
          case 0:
              if(j<w_finish)
              {
                  j++;
              }
              else
              {
                  w_finish--;
                  key=1;
                  i++;
              }
              break;
          case 1:
              if(i<h_finish)
              {
                  i++;
              }
              else
              {
                  h_finish--;
                  key=2;
                  j--;
              }
              break;
          case 2:
              if(j>w_start)
              {
                  j--;
              }
              else
              {
                  w_start++;
                  key=3;
                  i--;
              }
              break;
          case 3:
              if(i>h_start)
              {
                  i--;
              }
              else
              {
                  h_start++;
                  key=0;
                  j++;
              }
              break;
        }
    
      arr[i,j]=count;
      
      count++;
    }
     
    return arr;
  }
  
  public static void FillArr(int row,int column, int[,]arr,int count,int key)
  {
      if((row>=0)&&(row<arr.GetLength(0))&&(column>=0)&&
      (column<arr.GetLength(1))&&(arr[row,column]==0))
      {
          arr[row,column]=count;
          count++;
          
          switch(key)
          {
            case 0:
                FillArr(row,column+1,arr,count,0);
                key=1;
                FillArr(row+1,column,arr,count,1);
                break;
            case 1:
                FillArr(row+1,column,arr,count,1);
                key=2;
                FillArr(row,column-1,arr,count,2);
                break;
            case 2:
                FillArr(row,column-1,arr,count,2);
                key=3;
                FillArr(row-1,column,arr,count,3);
                break;
            case 3:
                FillArr(row-1,column,arr,count,3);
                key=0;
                FillArr(row,column+1,arr,count,0);
                break;
          }
      }
  }
  
  public static int[,]HelicalFilling(int[]param)
  {
      int [,]arr=new int[param[0],param[1]];
      
      for(int i=0;i<param[0];i++)
      {
          for(int j=0;j<param[1];j++)
          {
              arr[i,j]=0;
          }
      }
      int count=1;
      FillArr(0,0,arr,count,0);
    
      return arr;
  }
  
  public static bool CheckNum(int[,,]arr,int num)
  {
      for(int i=0;i<arr.GetLength(0);i++)
      {
          for(int j=0;j<arr.GetLength(1);j++)
          {
              for(int l=0;l<arr.GetLength(2);l++)
              {
                  if(arr[i,j,l]==num)
                  {
                      return true;
                  }
              }
          }
      }
      return false;
  }
  
  public static int[,,] ThreeDimentionArr(int[]param)
  {
      Random rand=new Random();
      int num=0;
      int[,,]arr;
      if((param[0]*param[1]*param[2])>89)
      {
          Console.WriteLine("Too big array for two-digit numbers");
          arr=new int[1,1,1];
          return arr;
      }
      else
      {
          arr=new int[param[0],param[1],param[2]];
      }

      for(int i=0;i<arr.GetLength(0);i++)
      {
          for(int j=0;j<arr.GetLength(1);j++)
          {
              for(int l=0;l<arr.GetLength(2);l++)
              {
                  while(CheckNum(arr,num))
                  {
                      num=rand.Next(10,100);
                  }
                  arr[i,j,l]=num;
              }
          }
      }
      return arr;
  }
  
  public static void Print3DMatrix(int[,,]arr)
  {
      for(int i=0;i<arr.GetLength(0);i++)
      {
          for(int j=0;j<arr.GetLength(1);j++)
          {
              for(int l=0;l<arr.GetLength(2);l++)
              {
                  Console.WriteLine($"{arr[i,j,l]}({i},{j},{l})");
              }
          }
      }
  }
  
  public static int[,]MatrixProduct(int[,]matrix1,int[,]matrix2)
  {
      int[,]arr=new int[matrix1.GetLength(0),matrix2.GetLength(1)];
      if(matrix1.GetLength(1)!=matrix2.GetLength(0))
      {
          Console.WriteLine("Matrixes are not compatible");
          return arr;
      }

      for(int k=0;k<arr.GetLength(0);k++)
      {
          for(int i=0;i<arr.GetLength(1);i++)
          {
              for(int j=0;j<matrix1.GetLength(1);j++)
              {
                  arr[k,i]+=matrix1[k,j]*matrix2[j,i];
              }
          }
      }
      return arr;
  }
  
  public static int SmallestRow(int[,]arr)
  {
      int num=0;
      int sum=0;
      int min_sum=1000000;
      for(int i=0;i<arr.GetLength(0);i++)
      {
          sum=0;
          for(int j=0;j<arr.GetLength(1);j++)
          {
              sum+=arr[i,j];
          }
          if(sum<min_sum)
          {
              num =i;
              min_sum=sum;
          }
      }
      return num;
  }
  
  public static void SortArrRow(int[,]arr)
  {
      int temp=0;
      for(int i=0;i<arr.GetLength(0);i++)
      {
          for(int j=0;j<arr.GetLength(1)-1;j++)
          {
              for(int l=j+1;l<arr.GetLength(1);l++)
              {
                  if(arr[i,j]<arr[i,l])
                  {
                      temp=arr[i,j];
                      arr[i,j]=arr[i,l];
                      arr[i,l]=temp;
                  }
              }
          }
      }
  }
 
  public static int[]ArrQuery()
  {
      int[]arr=new int[4];
      Console.WriteLine("Enter num of rows");
      arr[0]=int.Parse(Console.ReadLine());
      Console.WriteLine("Enter num of columns");
      arr[1]=int.Parse(Console.ReadLine());
      Console.WriteLine("Enter min value");
      arr[2]=int.Parse(Console.ReadLine());
      Console.WriteLine("Enter max value");
      arr[3]=int.Parse(Console.ReadLine());
      return arr;
  }
  
  public static int[]ArrQuery(bool key)
  {
      int[]arr=new int[3];
      Console.WriteLine("Enter num of rows");
      arr[0]=int.Parse(Console.ReadLine());
      Console.WriteLine("Enter num of columns");
      arr[1]=int.Parse(Console.ReadLine());
      if(key)
      {
          Console.WriteLine("Enter num of subrows");
          arr[2]=int.Parse(Console.ReadLine());
      }
      else
      {
          arr[2]=0;
      }

      return arr;
  }
  
  public static int[,]MakeArr_int(int[]param)
  {
      int [,]arr=new int[param[0],param[1]];
      Random rand=new Random();
      for(var i=0;i<param[0];i++)
      {
          for(var j=0;j<param[1];j++)
          {
              arr[i,j]=rand.Next(param[2],param[3]);
          }
      }
      return arr;
  }
  
  public static void MyClear()
  {
      Console.WriteLine("Press Enter key");
      Console.ReadLine();
      Console.Clear();
  }
  
  public static void PrintMatrix(int[,]arr)
  {
      for(var i=0;i<arr.GetLength(0);i++)
      {
          for(var j=0;j<arr.GetLength(1);j++)
          {
              Console.Write($"{arr[i,j]} ");
          }
          Console.WriteLine();
      }
      Console.WriteLine();
  }
  
  public static void PrintTwoMatrix(int[,]arr,int[,]arr2)
  {
      int com_row=0; 
      if(arr.GetLength(0)>arr2.GetLength(0))
      {
          com_row=arr.GetLength(0);
      }
      else
      {
          com_row=arr2.GetLength(0);
      }
      
      for(var i=0;i<com_row;i++)
      {
          for(var j=0;j<arr.GetLength(1);j++)
          {
              if(i<arr.GetLength(0))
              {
                Console.Write($"{arr[i,j]} ");
              }
              else
              {
                  Console.Write("  ");
              }
          }
          Console.Write("| ");
          for(var j=0;j<arr2.GetLength(1);j++)
          {
              if(i<arr2.GetLength(0))
              {
                Console.Write($"{arr2[i,j]} ");
              }
          }
          Console.WriteLine();
      }
      Console.WriteLine();
  }
  
  public static void PrintMatrixFormat(int[,]arr)
  {
      for(var i=0;i<arr.GetLength(0);i++)
      {
          for(var j=0;j<arr.GetLength(1);j++)
          {
              Console.Write(String.Format("{0:000}", arr[i,j]));
              Console.Write(" ");
          }
          Console.WriteLine();
      }
      Console.WriteLine();
  }

}




