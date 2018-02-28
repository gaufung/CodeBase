package main

import (
	"math"
	"fmt"
	"time"
)

func calcluate_pi(n int) float64{
	ch := make(chan float64)
	for k:=0; k<=n;k++{
		go term(ch, float64(k))
	}
	f := 0.0
	for k:=0; k <= n; k++{
		f += <-ch
	}
	return f
}


func term(ch chan float64, k float64){
	ch <- 4 * math.Pow(-1, k) / (2*k + 1)
}

func main(){
	start:=time.Now()
	fmt.Println(calcluate_pi(1000000))
	end := time.Now()
	delta := end.Sub(start)
	fmt.Println("Cost time: ", delta)
}