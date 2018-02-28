package org.iecas.pda.model;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 * The base type of factor of pda model
 * @author  Feng Gao
 * @email guafung@outlook.com
 */
public  abstract class FactorBase  implements Serializable{
    protected String name;
    protected List<Double> components;
    protected int size;

    public FactorBase(String name, List<Double> components){
        this.name = name;
        this.components = components;
        this.size = this.components.size();
    }
    public FactorBase(String name){
        this.name = name;
        this.components = new ArrayList<>();
    }
    public void updatetotal(){
        double currentTotal = this.components.stream().mapToDouble(i->i).sum()-this.components.get(this.size-1);
        this.components.set(size-1,currentTotal);
    }
}
