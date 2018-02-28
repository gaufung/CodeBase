package org.iecas.pda.lp;

import org.iecas.pda.model.Dmu;
import scpsolver.constraints.LinearBiggerThanEqualsConstraint;
import scpsolver.constraints.LinearEqualsConstraint;
import scpsolver.lpsolver.LinearProgramSolver;
import scpsolver.lpsolver.SolverFactory;
import scpsolver.problems.LinearProgram;

import java.util.Arrays;
import java.util.List;

/**
 * Created by gaufung on 25/06/2017.
 */
public class PhiMin extends AbstractOptimize {

    public PhiMin(List<Dmu> dmusLeft, List<Dmu> dmusRight){
        super(dmusLeft, dmusRight);
    }

    @Override
    protected double optimize(double[] energies, double[] co2s, double[] productions, double energy,
                            double co2, double production){
        LinearProgram lp = new LinearProgram(energies);
        lp.addConstraint(new LinearBiggerThanEqualsConstraint(productions,production,"c1"));
        lp.addConstraint(new LinearEqualsConstraint(co2s,co2,"c2"));
        LinearProgramSolver solver  = SolverFactory.newDefault();
        lp.setMinProblem(true);
        double[] lowerBound = new double[energies.length];
        lp.setLowerbound(lowerBound);
        try{
            double[] sol = solver.solve(lp);
            double result = 0.0;
            for(int i =0,length=sol.length;i<length;i++){
                result += energies[i]*sol[i];
            }
            return result/energy;
        }catch (Exception e){
            return -1.0;
        }

    }

    @Override
    protected Double[] feasible(){
        double[] e = new double[this.dmusCount+1];
        double[] p = new double[this.dmusCount+1];
        double[] c = new double[this.dmusCount+1];
        for(int i = 0;i<this.dmusCount;i++){
            e[i] = this.dmusLeft.get(i).getEnergy().total();
            p[i] = this.dmusLeft.get(i).getProduction().getProduction();
            c[i] = this.dmusLeft.get(i).getCo2().total();
        }
        e[this.dmusCount] = 1.0;
        p[this.dmusCount] = 0.0;
        c[this.dmusCount] = 0.0;
        Double[] feasibleOptimize = new Double[this.dmusCount];
        for(int i =0; i<this.dmusCount;i++){
            feasibleOptimize[i] = this.optimize(e,c,p,
                    this.dmusRight.get(i).getEnergy().total(),
                    this.dmusRight.get(i).getCo2().total(),
                    this.dmusRight.get(i).getProduction().getProduction());
        }
        return feasibleOptimize;
    }

    @Override
    protected Double[] infeasible(){
        double[] e = new double[this.dmusCount+2];
        double[] p = new double[this.dmusCount+2];
        double[] c = new double[this.dmusCount+2];
        for(int i = 0;i<this.dmusCount;i++){
            e[i] = this.dmusLeft.get(i).getEnergy().total();
            p[i] = this.dmusLeft.get(i).getProduction().getProduction();
            c[i] = this.dmusLeft.get(i).getCo2().total();
        }
        e[this.dmusCount] = 1.0;
        e[this.dmusCount+1]=0.0;
        p[this.dmusCount] = 0.0;
        p[this.dmusCount+1]=0.0;
        c[this.dmusCount] = 0.0;
        c[this.dmusCount+1]=-1.0;
        Double[] infeasibleOptimize = new Double[this.dmusCount];
        for(int i =0; i<this.dmusCount;i++){
            infeasibleOptimize[i] = this.optimize(e,c,p,
                    this.dmusRight.get(i).getEnergy().total(),
                    this.dmusRight.get(i).getCo2().total(),
                    this.dmusRight.get(i).getProduction().getProduction());
        }
        return infeasibleOptimize;
    }

    @Override
    public List<Double> optimize() {
        Double[] feasibleOptimize = feasible();
        Double[] infeasibleOptimize = infeasible();
        for(int i =0, length=feasibleOptimize.length; i < length; i++){
            if(feasibleOptimize[i]==-1.0){
                feasibleOptimize[i]= infeasibleOptimize[i];
            }
        }
        return Arrays.asList(feasibleOptimize);
    }
}
