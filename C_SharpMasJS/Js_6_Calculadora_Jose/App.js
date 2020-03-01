class App
{


    constructor()
    {

    }

    BtClick_Press(num)
    {
        TbResult.value += num;
    }

    BtClick_Sum()
    {
        let conversionResult = this.TryReadAndConvert();
        if (conversionResult.IsSuccess)
        {
            this.FirstNumber = conversionResult.Value;
            this.CurrentOperation = Operations.Add;
        }
    }
    
    BtClick_Sub()
    {
        let conversionResult = this.TryReadAndConvert();
        if (conversionResult.IsSuccess)
        {
            this.FirstNumber = conversionResult.Value;
            this.CurrentOperation = Operations.Sub;
        }
    }
    
    BtClick_Mult()
    {
        let conversionResult = this.TryReadAndConvert();
        if (conversionResult.IsSuccess)
        {
            this.FirstNumber = conversionResult.Value;
            this.CurrentOperation = Operations.Mult;
        }
    }
    
    BtClick_Div()
    {
        let conversionResult = this.TryReadAndConvert();
        if (conversionResult.IsSuccess)
        {
            this.FirstNumber = conversionResult.Value;
            this.CurrentOperation = Operations.Div;
        }
    }

    BtClick_Calc()
    {
        let conversionResult = this.TryReadAndConvert();
        
        if (conversionResult.IsSuccess)
        {
            let secondNumber = conversionResult.Value;

            switch (this.CurrentOperation) 
            {
                case Operations.Add:                    
                    TbResult.value = this.FirstNumber + secondNumber;    
                    break;
                case Operations.Sub:                    
                    TbResult.value = this.FirstNumber - secondNumber;    
                    break;
                case Operations.Mult:                    
                    TbResult.value = this.FirstNumber * secondNumber;    
                    break;
                case Operations.Div:                    
                    TbResult.value = this.FirstNumber / secondNumber;    
                    break;
            
                default:
                    break;
            }
        }
    }

    TryReadAndConvert()
    {
        let output = { IsSuccess: false, Value: null };

        output.Value = Number(TbResult.value);
        output.IsSuccess = output.Value !== NaN;

        if (output.IsSuccess)
        {
            TbResult.value = "";            
        }
        else
        {
            TbResult.value = "0";
        }

        // esto es lo mismo que lo anterior, queda más elegante
        TbResult.Value = output.IsSuccess ? "" : 0;
        

        return output;
    }
}

Operations =
{
    Add: 1,
    Sub: 2,
    Mult: 3,
    Div: 4
}

var app = new App(); 