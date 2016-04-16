import java.util.*;

public class EstrategiaAntiNoturnos implements EstrategiaDeAtaque {
    private ArrayList<Elfo> ordemDoUltimoAtaque = new ArrayList<>();

    public ArrayList<Elfo> getOrdemDoUltimoAtaque() {
        return this.ordemDoUltimoAtaque;
    }

    public void atacar(ArrayList<Elfo> pelotao, ArrayList<Dwarf> dwarves) {
        this.ordemDoUltimoAtaque.clear();

        // 1 - Filtrar VIVOS
        // C#
        // var vivos = elfos.Where(x => x.Status == Status.VIVO);
        ArrayList<Elfo> vivos = vivos(pelotao);

        // 2 - Variáveis de controle para quantidade de ataques.
        int intencoesAtaque = vivos.size() * dwarves.size();
        int limiteAtaquesElfosNoturnos = (int)(intencoesAtaque * 0.3);
        int qtdAtaquesFeitosPorNoturnos = 0;

        // 3 - Percorrendo lista de vivos para desferir os ataques seguindo as regras
        for (Elfo elfoQueVaiAtacar : vivos) {
            for (Dwarf dwarf : dwarves) {
                boolean éElfoNoturno = elfoQueVaiAtacar instanceof ElfoNoturno;

                if (éElfoNoturno) {
                    boolean devePularParaOProximo = qtdAtaquesFeitosPorNoturnos >= limiteAtaquesElfosNoturnos;
                    if (devePularParaOProximo) {
                        continue;
                    }
                    qtdAtaquesFeitosPorNoturnos++;
                }

                ordemDoUltimoAtaque.add(elfoQueVaiAtacar);
                elfoQueVaiAtacar.atirarFlecha(dwarf);
            }
        }
    }

    private ArrayList<Elfo> vivos(ArrayList<Elfo> pelotao) {
        ArrayList<Elfo> vivos = new ArrayList<>();
        for (Elfo elfo : pelotao) {
            if (elfo.getStatus() == Status.VIVO) {
                vivos.add(elfo);
            }
        }
        return vivos;
    }
}