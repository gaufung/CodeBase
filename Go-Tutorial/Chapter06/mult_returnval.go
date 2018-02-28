package main

import "fmt"

func main(){
	sum, multi, sub := sum_multi_sub(3, 4)
	fmt.Printf("%d and %d 's sum is %d; multiply is %d; substr" +
		"act is %d\n", 3, 4, sum, multi, sub)
}

func sum_multi_sub(num1, num2 int)(sum, multi, sub int){
	sum = num1 + num2
	multi = num1 * num2
	sub = num1 - num2
	return
}
