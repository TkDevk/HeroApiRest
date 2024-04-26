import axios from "axios"
import { useState } from "react"
const BASEURL = "https://localhost:7012/api/hero";
const InputTextHero = ()=>{

  const[InputHeroName, setInputHeroName] = useState("");
  const[InputName, setInputHero] = useState("");
  const onSubmit = async(e)=>{
    e.preventDefault();
      if(InputName=="" && InputHeroName==""){
        console.log("pls place a hero name")
      }else{
        
      await axios.post(BASEURL,{
            InputName,
            InputHeroName
        })
        .then(response=>{
           console.log(response.data);
        }).catch(err=>{
         console.log(err.data);
        });
        setInputHeroName("");
        setInputHero("");
      } 
  }
    return (
        <>
        <form onSubmit={onSubmit}>
            <input 
            value={InputName}
            onChange={e=>setInputHero(e.target.value)}
            placeholder="Insert the hero name"
            />
            <input 
            value={InputHeroName}
            onChange={e=>setInputHeroName(e.target.value)}
            placeholder="Insert the new Power"
            />
        <button>Send</button>
        </form>
        </>
    )
}
export default InputTextHero