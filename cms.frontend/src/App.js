//import logo from './logo.svg';
//import './App.css';

//function App() {
//  return (
//    <div className="App">
//      <header className="App-header">
//        <img src={logo} className="App-logo" alt="logo" />
//        <p>
//          Edit <code>src/App.js</code> and save to reload.
//        </p>
//        <a
//          className="App-link"
//          href="https://reactjs.org"
//          target="_blank"
//          rel="noopener noreferrer"
//        >
//          Learn React - Trường Cao Đẳng Công thương TPHCM - 2026
//        </a>
//      </header>
//    </div>
//  );
//}

//export default App;


import React from 'react';

import CategoryProductList from './components/CategoryProductList';
import ProductList from './components/ProductList';
import PostList from './components/PostList';

import './App.css';

function App() {
    return (
        <div className="container mt-5">

            {/* HEADER */}
            <header className="pb-3 mb-4 border-bottom">
                <span className="fs-4 font-weight-bold text-dark text-uppercase">
                    🛒 THAICMS RETAIL - HỆ THỐNG BÁN HÀNG & TIN TỨC THỜI TRANG
                </span>
            </header>

            {/* ===================== */}
            {/* KHU VỰC 1: SHOPPING */}
            {/* ===================== */}
            <div className="row">

                {/* LEFT: CATEGORY */}
                <div className="col-md-3">
                    <CategoryProductList />
                </div>

                {/* RIGHT: PRODUCTS */}
                <div className="col-md-9">

                    <h4 className="mb-4 text-uppercase text-secondary font-weight-bold">
                        Danh sách sản phẩm
                    </h4>

                    <ProductList />

                </div>
            </div>

            {/* ===================== */}
            {/* KHU VỰC 2: BLOG */}
            {/* ===================== */}
            <div className="row mt-5">

                <div className="col-12">

                    <PostList />

                </div>

            </div>

        </div>
    );
}

export default App;