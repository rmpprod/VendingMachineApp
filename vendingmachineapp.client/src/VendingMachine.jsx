import React, { useState, useEffect } from 'react';

const VendingMachine = () => {
  const [brands, setBrands] = useState([]);
  const [products, setProducts] = useState([]);
  const [selectedBrand, setSelectedBrand] = useState('Все бренды');
  const [minPrice, setMinPrice] = useState(0);
  const [maxPrice, setMaxPrice] = useState(100);
  const [cart, setCart] = useState([]);
  const [excelFile, setExcelFile] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      const brandResponse = await fetch('/api/brands');
      const productResponse = await fetch('https://localhost:7243/Home');
      const brandsData = await brandResponse.json();
      const productsData = await productResponse.json();

      setBrands(brandsData);
      setProducts(productsData);
      setMinPrice(Math.min(...productsData.map(product => product.price)));
      setMaxPrice(Math.max(...productsData.map(product => product.price)));
    };

    fetchData();
  }, []);

  const handleBrandChange = (e) => {
    setSelectedBrand(e.target.value);
    const filteredProducts = products.filter(product => 
      e.target.value === 'Все бренды' || product.brand === e.target.value
    );
    setMinPrice(Math.min(...filteredProducts.map(product => product.price)));
    setMaxPrice(Math.max(...filteredProducts.map(product => product.price)));
  };

  const handleAddToCart = (product) => {
    if (product.quantity > 0) {
      setCart([...cart, product]);
      product.quantity -= 1;
    }
  };

  const handleFileChange = (e) => {
    setExcelFile(e.target.files[0]);
  };

  const handleFileUpload = async () => {
    if (!excelFile) return;

    const formData = new FormData();
    formData.append('file', excelFile);

    await fetch('https://localhost:7243/Home', {
      method: 'POST',
      body: formData,
    });

    // Обновить список продуктов после импорта
    const response = await fetch('https://localhost:7243/Home');
    const productsData = await response.json();
    setProducts(productsData);
  };

  const totalItemsInCart = cart.length;

  return (
    <div>
      <h1>Газированные напитки</h1>
      <div>
        <label>Бренд:</label>
        <select onChange={handleBrandChange}>
          <option>Все бренды</option>
          {brands.map(brand => (
            <option key={brand.id} value={brand.name}>{brand.name}</option>
          ))}
        </select>
      </div>
      <div>
        <label>Стоимость:</label>
        <input 
          type="range" 
          min={minPrice} 
          max={maxPrice} 
          step="1" 
          onChange={(e) => { /* Обработка изменения ползунка */ }} 
        />
        <span>{`От ${minPrice} до ${maxPrice}`}</span>
      </div>
      <div className="product-catalog">
        {products.map(product => (
          <div key={product.id} className="product">
            <h3>{product.name}</h3>
            <p>Цена: {product.price} руб.</p>
            <button 
              onClick={() => handleAddToCart(product)} 
              disabled={product.quantity === 0}
            >
              {product.quantity === 0 ? 'Закончился' : 'Выбрать'}
            </button>
          </div>
        ))}
      </div>
      <button disabled={totalItemsInCart === 0}>
        {totalItemsInCart > 0 ? `Выбрано: ${totalItemsInCart}` : 'Нет выбранных товаров'}
      </button>
      <div>
        <input type="file" accept=".xlsx, .xls" onChange={handleFileChange} />
        <button onClick={handleFileUpload}>Импортировать Excel</button>
      </div>
    </div>
  );
};

export default VendingMachine;
