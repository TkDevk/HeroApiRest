import { useState } from "react";
import axios from "axios";
const BASEURL = "https://localhost:7012/api/hero";

const InputHero = () => {
  const [isId, setIsId] = useState([]);
  const [inputData, setInputData] = useState({
    inputName: "",
    inputHeroName: "",
    inputPower: "",
  });
  const onSubmitForm = async (e) => {
    e.preventDefault();
    if(inputData.inputHeroName=="" && inputData.inputHeroName=="" &&inputData.inputHeroName==""){
        console.log("please full all the spaces");
    }else{
    
    try {
      const response = await axios.get(BASEURL);
      setIsId(response.data);
      const maxId = isId.length;
      console.log(maxId);

      await axios
        .post(BASEURL, {
          inputName: inputData.inputName,
          inputHeroName: inputData.inputHeroName,
        })
        .catch((err) => console.log(err));
        await axios.post(`${BASEURL}/${maxId+1}/superpower/`,{
            inputPower : inputData.inputPower,
            skillLevel : 0
        }).catch(err=>console.log(err));
    } catch (error) {
      console.log(error);
    }}
  };

  const handleInput = (e) => {
    const { value, name } = e.target;
    //Create new oBj
    setInputData({
      ...inputData,
      //property[]
      [name]: value,
    });
  };

  return (
    <>
    
      <form
        onSubmit={onSubmitForm}
        style={{ display: "flex", flexDirection: "column", gap: ".5rem" }}
      >
        <input
          type="text"
          name="inputName"
          value={inputData.inputName}
          onChange={handleInput}
          placeholder=" Place Human Name"
        />
        <input
          type="text"
          name="inputHeroName"
          value={inputData.inputHeroName}
          onChange={handleInput}
          placeholder=" Place Hero Name"
        />
        <input
          type="text"
          name="inputPower"
          value={inputData.inputPower}
          onChange={handleInput}
          placeholder=" Place Super Power"
        />
        <button> Send </button>
      </form>
    </>
  );
};
export default InputHero;
