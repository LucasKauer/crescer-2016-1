import java.util.*;

public class SindarinParaIngles implements TradutorSindarin {
    private HashMap<String, String> dicionario = new HashMap<String, String>()
    {
        {
            put("naur", "fire");
        }
    };

    public String traduzir(String palavraEmSindarin) {
        return dicionario.get(palavraEmSindarin);
    }
    
    // não está na interface, precisaria fazer casting
    public void limpar() {
        dicionario.clear();
    };
}










