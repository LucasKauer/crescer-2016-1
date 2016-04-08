public class Dwarf {
    private int vida = 110;
    private String nome;
    private Status status = Status.VIVO;
    private Inventario inventario = new Inventario();
    private DataTerceiraEra dataNascimento;

    public Dwarf(String nome) {
        this.vida = 110;
        this.nome = nome;
        this.dataNascimento = new DataTerceiraEra(1, 1, 1);
    }
    
    public Dwarf(String nome, DataTerceiraEra dataNascimento) {
        this(nome);
        this.dataNascimento = dataNascimento;
    }

    public void perderVida() {
        // this.vida = this.vida - 10;
        // vida -= 10;
        int vidaAposFlechada = this.vida - 10;
        if (vidaAposFlechada == 0) {
            status = Status.MORTO;
        }

        if (vida > 0) {
            vida = vidaAposFlechada;
        }
    }

    public void setNome(String novoNome) {
        nome = novoNome;
    }

    public String getNome() {
        return nome;
    }

    public int getVida() {
        return this.vida;
    }

    public Status getStatus() {
        return this.status;
    }
    
    public Inventario getInventario() {
        return this.inventario;
    }
    
    public DataTerceiraEra getDataNascimento() {
        return this.dataNascimento;
    }
    
    public void adicionarItem(Item item) {
        this.inventario.adicionarItem(item);
    }
    
    public void perderItem(Item item) {
        this.inventario.removerItem(item);
    }

    /*private void tirarVida() {
    this.vida -= 10;
    }*/

    // Declarar um objeto:
    // Dwarf gimli = null;

    // Criação (instanciação):
    // new Dwarf();
    // Dwarf d1 = new Dwarf();

}






