import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class DataTerceiraEraTest
{
    @Test
    public void criarAno1600QueEhBissexto() {
        // Arrange
        DataTerceiraEra data = new DataTerceiraEra(1, 1, 2000);
        // Act
        boolean obtido = data.ehBissexto();
        // Assert
        assertTrue(obtido);
    }
    
    @Test
    public void criarAno2012QueEhBissexto() {
        // Arrange
        DataTerceiraEra data = new DataTerceiraEra(04, 05, 2012);
        // Act
        boolean obtido = data.ehBissexto();
        // Assert
        assertTrue(obtido);
    }
    
    @Test
    public void criarAno2200QueNaoEhBissexto() {
        // Arrange
        DataTerceiraEra data = new DataTerceiraEra(04, 05, 2200);
        // Act
        boolean obtido = data.ehBissexto();
        // Assert
        assertFalse(obtido);
    }
    
    @Test
    public void criarAno2015QueNaoEhBissexto() {
        // Arrange
        DataTerceiraEra data = new DataTerceiraEra(04, 05, 2015);
        // Act
        boolean obtido = data.ehBissexto();
        // Assert
        assertFalse(obtido);
    }
}

















