import { Checkbox, FormControl, FormControlLabel, FormGroup, FormLabel } from "@mui/material";
import { useField, useFormikContext } from "formik";
import React from "react";

interface OmCheckBoxProps{
    name: string,
    label: string,
    legend: string,
    otherProps: any
}

export default function OmCheckBox({name, label, legend, otherProps}: OmCheckBoxProps){
    const {setFieldValue} = useFormikContext();
    const [field,meta] = useField(name);

    function handleChange(event: any){
        const {checked } = event.target;
        setFieldValue(name, checked);
    }

    const configCheckBox = {
        ...otherProps,
        ...field,
        onchange: handleChange,
        checked: meta.value
    }

    const configFormControl: any = {};
    if(meta && meta.touched && meta.error){
        configFormControl.error = true;        
    }

    return(
        <FormControl {...configFormControl}>
            <FormLabel component= 'legend'>{legend}</FormLabel>
            <FormGroup>
                <FormControlLabel
                    control={<Checkbox {...configCheckBox}/>}
                    label={label}
                />
            </FormGroup>
        </FormControl>
    );
}