package main

import "fmt"

func main(){
	var mapList map[string]int
	var mapAssigned map[string]int
	mapList = map[string]int{"one":1, "two":2}
	mapCreated := make(map[string]float32)
	mapAssigned = mapList
	mapCreated["Key1"] = 4.5
	mapCreated["key2"] = 3.14259
	mapAssigned["two"] = 3

	fmt.Println(mapList["one"])
	fmt.Println(mapCreated["key2"])
	fmt.Println(mapList["two"])
	fmt.Println(mapList["ten"])
}
