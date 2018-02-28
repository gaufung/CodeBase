package main

import "fmt"
func mapFunc(a []int, f func (int) int) []int{
	result := make([]int, len(a))
	for i, val := range a{
		result[i] = f(val)
	}
	return result
}

func main(){
	a := []int{1, 2, 3}
	b := mapFunc(a, f1)
	fmt.Print(b)
}

func f1(val int) (result int){
	result = val *10
	return
}
