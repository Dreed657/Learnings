function addItem() {
    let text = document.getElementById('newItemText');
    let Fvalue = document.getElementById('newItemValue');

    let select = document.getElementById('menu');

    var option = document.createElement('option');
        option.text = text.value;
    
    select.add(option, Fvalue.value);

    text.value = '';
    Fvalue.value = '';
}


