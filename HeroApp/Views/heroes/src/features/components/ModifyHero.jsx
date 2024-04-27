import axios from "axios"
import { useState } from "react";
const BASEURL = "https://localhost:7012/api/hero";
const ModifyHero = ({heroId})=>{
    const [isOpen, setIsOpen] = useState(false);
    const [inputEditData, setInputEditData] = useState({
        inputName: "",
        inputHeroName:""
    });

    const handleDelete = ()=>{
    axios.delete(`${BASEURL}/${heroId}`,
    { data: heroId 
    });
    };

    const handleEdit = ()=>{
     setIsOpen(prev=>!prev)
    };
    
    const inputOnChange = (e)=>{
        const {name, value} = e.target;
        setInputEditData({
            ...inputEditData,
            [name] : value
        });
    };

    const OnSubmit = (e)=>{
        e.preventDefault();
        axios.put(`${BASEURL}/${heroId}`,{
           inputName: inputEditData.inputName,
           inputHeroName: inputEditData.inputHeroName
        });
    };

    return (
        <>
           <button onClick={handleDelete}> Delete </button>
           <button onClick={handleEdit}> Edit </button>
           {isOpen&&<form onSubmit={OnSubmit}>
            <input 
            type="text" 
            name="inputName"
            value={inputEditData.inputName}
            onChange={inputOnChange}
            />
            <input 
            type="text"
            name="inputHeroName"
            value={inputEditData.inputHeroName}
            onChange={inputOnChange} 
            />
            <button> Save </button>
           </form>}
           
        </>
    )
}
export default ModifyHero