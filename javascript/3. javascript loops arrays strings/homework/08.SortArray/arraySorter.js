function sortArray(arr) {
    var len = arr.length, min, temp;

    for(i = 0; i < len; i++) {
        min = i;

        for(j = i + 1; j < len; j++) {
            if(arr[j] < arr[min]){
                min = j;
            }
        }

        if (i != min){
            temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }
    }

    return arr;
}

console.log(sortArray([5, 4, 3, 2, 1]));
console.log(sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]));