package main

import "fmt"

func main(){
	x := min(1, 2, 3, 0, 1)
	fmt.Printf("the minimum is: %d\n", x)
	arr := []int{7, 9, 19, 2, 1}
	x = min(arr...)
	fmt.Printf("The minimum is: %d\n", x)

}

func min(a ...int) int{
	if len(a)==0{
		return 0
	}
	min := a[0]
	for _, v := range  a{
		if v < min{
			min = v
		}
	}
	return min
}
