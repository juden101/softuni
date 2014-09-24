import java.io.FileInputStream;
import java.util.TreeMap;
import org.apache.poi.xssf.usermodel.XSSFCell;
import org.apache.poi.xssf.usermodel.XSSFRow;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

public class _11_Excel {

    public static void main(String[] args) {
        try (FileInputStream input = new FileInputStream("src\\_11_IncomesReport.xlsx")) {
            XSSFWorkbook wb = new XSSFWorkbook(input);
            XSSFSheet sheet = wb.getSheet("Incomes");
            TreeMap<String, Double> allOffices = new TreeMap<>();
            double totalIncome = 0;

            XSSFRow currentRow = sheet.getRow(1);
            while (currentRow != null) {
                XSSFCell officeCell = currentRow.getCell(0);
                String currentOffice = officeCell.getStringCellValue();
                XSSFCell incomeCell = currentRow.getCell(5);
                
                double currentIncome = incomeCell.getNumericCellValue();
                totalIncome += currentIncome;
                
                if (allOffices.containsKey(currentOffice)) {
                    currentIncome += allOffices.get(currentOffice);
                }
                
                allOffices.put(currentOffice, currentIncome);
                currentRow = sheet.getRow(1 + currentRow.getRowNum());
            }
            
            allOffices.keySet().stream().forEach((office) -> {
                double income = allOffices.get(office);
                
                System.out.printf("%s -> %.2f\n", office, income);
            });
            
            System.out.printf("%s -> %.2f\n", "Grand Total", totalIncome);
        } catch (Exception e) {
            System.out.println("Error!");
        }
        
    }
    
}
