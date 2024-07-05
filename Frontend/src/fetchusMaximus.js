const postfetch = async (path, formdata) => {
  try {
    const response = await fetch(path,
      {
        method: "POST",
        body: formdata,
      }
    );
    if (response.ok) {
      return await response.json();
    } else {
      return await response.json();
    }
  } catch (error) {
    return "Error";
  }
};

export { postfetch };