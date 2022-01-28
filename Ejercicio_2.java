package EjerciciosArrays;
import java.util.Locale;
import java.util.Scanner;
public class Ejercicio_2 {

    public static boolean CheckAlphabeticChar(char charToCheck){
        String alphabeticControl ="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int alphabeticCounter = 0;

        for (int i = 0; i < alphabeticControl.length(); i++) {
            if (charToCheck == alphabeticControl.charAt(i)){
                alphabeticCounter++;
            }
        }
        if (alphabeticCounter == 1){
            return true;
        }
        else{
            return false;
        }
    }
    public static boolean CheckAlphaNumericChar(char charToCheck){
        String alphaNumericControl = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        int alphanumericCounter = 0;

        for (int i = 0; i < alphaNumericControl.length(); i++) {
            if (charToCheck == alphaNumericControl.charAt(i)){
                alphanumericCounter++;
            }
        }
        if (alphanumericCounter == 1){
            return true;
        }
        else{
            return false;
        }
    }
    public static boolean CheckIsNumber (String numberToCheck){
        try {
            long  numericBlockInt = Long.parseLong(numberToCheck);
        }
        catch(Exception e){
            System.err.println(e);
            return false;
        }
        return true;
    }

    public static boolean CheckId(String useridUser){
        boolean correctIdCard = false;
        String userid = useridUser;

        if (userid.length() == 9){
            String numericBlock = userid.substring(1,8);
            char firstChar = userid.charAt(0), lastChar = userid.charAt(8);

            if (CheckAlphabeticChar(userid.charAt(8)) == true &&
                    CheckAlphaNumericChar(userid.charAt(0)) == true &&
                    CheckIsNumber(numericBlock) == true){
                correctIdCard = true;
            }
        }
        else{
            correctIdCard = false;
        }
        return correctIdCard;
    }

    public static boolean CheckUserName(String userName){
        String [] partsOfName = userName.split(" ");
        int counterCapitalLetters = 0, counterRestToLowerCase = 0;

        if (partsOfName.length >= 3){

            for (int i = 0; i < partsOfName.length; i++) {
                String partUpper = partsOfName[i].toUpperCase();
               if(partsOfName[i].charAt(0) == partUpper.charAt(0)) {
                   counterCapitalLetters++;
               }
            }
            for (int i = 0; i < partsOfName.length; i++) {
                String rest = partsOfName[i].substring(1,partsOfName[i].length());
                if(rest  == rest.toLowerCase()) {
                    counterRestToLowerCase++;
                }
            }
            if (counterCapitalLetters == partsOfName.length &&
            counterRestToLowerCase == partsOfName.length){
                return true;
            }
            else{
                return  false;
            }
        }
        else{
            return  false;
        }


    }
    public static boolean CheckBankAccount(String accountUser){
        String[] accountSplit = accountUser.split(" ");
        String accountString = "";


        for (int i = 0; i < accountSplit.length; i++) {
            accountString+=accountSplit[i];
        }
        String numericBlock = accountString.substring(2,20);

        if (CheckAlphabeticChar(accountString.charAt(0)) == true &&
                CheckAlphabeticChar(accountString.charAt(1)) == true &&
                CheckIsNumber(numericBlock) == true){
            return  true;
        }
        else {
        System.out.println(accountString + " " + accountString.charAt(0) + " "
                + accountString.charAt(1) + " " + accountString.substring(2,20));
        return false;}
    }
    public static boolean CheckBalance(float userBalance){
        if (userBalance > 0){
            return  true;
        }
        return false;
    }

    public static String FormatedAccount(String accountUser){
        String[] quartet = new String[5];
        String formatedAccount = "";

        for (int j = 0; j <=20; j+=4) {
            for (int i = 0; i < quartet.length; i++) {//ok
                quartet[i] = accountUser.substring(j,j+4);


            }

        }
        for (int i = 0; i < 4; i++) {
            formatedAccount += quartet[i] + " ";
        }


        return formatedAccount;
    }

    public static void main(String[] args) {
        String name,correctUserName,account,userid = args[0];
        Scanner sc = new Scanner(System.in);
        float initialBalance = 0;
        boolean correctID = CheckId(userid);

        if (correctID){
            System.out.println("Welcome to your favourite bank. ");
            System.out.println();
            System.out.println("Please, enter you full name: ");
            name = sc.nextLine();

            if(CheckUserName(name) == true){
                correctUserName = name;

                System.out.println("Please, enter your bank account");
                account = sc.nextLine();

                if(CheckBankAccount(account) == true){

                    System.out.println("Please enter the initial balance of " +
                            "your bank account");
                    initialBalance = sc.nextFloat();
                    if(CheckBalance(initialBalance)){
                        System.out.println("You've finished the registration " +
                                "successfully !!");
                        System.out.println("This is the information that " +
                                "you have provided:");
                        System.out.println();
                        System.out.println("ID card: " + userid );
                        System.out.println("Full name: " + correctUserName );
                        System.out.println("Bank account: " + FormatedAccount(account) );
                        System.out.printf("Initial balance: %.2f EUR" ,
                                initialBalance  );
                        System.out.println();


                    }
                    else{
                        System.out.println("Initial balance can't be negative");
                    }

                }
                else{
                    System.out.println("Bank account is not valid");
                }
            }
            else{
                System.out.println("User name is not valid");
            }
        }
        else{
            System.out.println(correctID + " Invalid ID card");
        }
    }
}
