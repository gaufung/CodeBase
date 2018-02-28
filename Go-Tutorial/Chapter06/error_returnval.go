package main


import (
	"fmt"
	"errors"
	"math"
)

func main(){
	fmt.Println("First example with -1")
	if ret, err := MySqrt(-1.0); err!=nil {
		fmt.Printf("the squrt root of %f is %f", -1.0, ret)
	}else{
		fmt.Printf("Error, %f", -1.0)
	}

}

func MySqrt(f float64)(float64, error){
	if f<0{
		return float64(math.NaN()), errors.New("Negative error")
	}else{
		return math.Sqrt(f), nil
	}
}