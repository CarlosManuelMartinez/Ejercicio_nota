/* Carlos Manuel Martinez Pomares. */
package EjerciciosArrays;

import java.util.Scanner;

public class CircleArea2 {

    public static void main(String[] args) {

	 final float PI = 3.14159F;
     Scanner sc = new Scanner(System.in);
     float userRadius;

     System.out.print("Write the radius of the circle: ");
     userRadius = sc.nextFloat();

     System.out.printf("the area of the circle with radius %.2f is; %.2f",
             userRadius,PI * userRadius * userRadius);
    }
}
