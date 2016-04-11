import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

public class IrishDwarfTest {
    @Test
    public void irishDwarfComSorte() {
        IrishDwarf dwarf = new IrishDwarf("Pete 'O Murphy", new DataTerceiraEra(1, 1, 2000));
        dwarf.adicionarItem(new Item(5, "Pint de Guinness"));
        dwarf.perderVida();
        dwarf.perderVida();
        dwarf.perderVida();
        dwarf.tentarSorte();
        assertEquals(15005, dwarf.getInventario().getItens().get(0).getQuantidade());
    }

    @Test
    public void irishDwarfSemSorte() {
        IrishDwarf dwarf = new IrishDwarf("Pete 'O Murphy");
        dwarf.adicionarItem(new Item(5, "Pint de Guinness"));
        dwarf.perderVida();
        dwarf.perderVida();
        dwarf.perderVida();
        dwarf.tentarSorte();
        assertEquals(5, dwarf.getInventario().getItens().get(0).getQuantidade());
    }
}
