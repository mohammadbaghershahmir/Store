let Directory = "";
let Directories = [""];
let UrlGet = "/Admin/FileManager/GetDirectoryList";
let selectorInput = "";
let selectMultiple = false;
let selectedFiles = [];

//select image
$(".select-image").on("click", function (e) {
    Directory = "";
    selectMultiple = false;
    $("#modalSelectFiles").show();
    selectorInput = $(this).attr('data-selector-id');
    $("#filemanager-body").html(loading);
    getDirectoryList();
});

//Select Image
function selectImage(urlFile, selector) {
    $(`#${selector}`).val(urlFile);
    $("#modalSelectFiles").hide();
}

//Select file
$(".select-images").on("click", function (e) {
    Directory = "";
    selectMultiple = true;
    $("#modalSelectFiles").show();
    $("#filemanager-body").html(loading);
    getDirectoryList();
});

//Manage Selected Files
$(document).on('click', '.selected-image-multiple', function (e) {
    $(this).each(function (index, value) {
        var item = $(value).attr('data-path');
        let status = $(value).is(':checked') ? true : false;
        if (status == true) {
            if (selectedFiles.includes(item) != true) {
                selectedFiles.push(item);
            }
        } else {
            if (selectedFiles.includes(item) == true) {
                selectedFiles.splice(selectedFiles.indexOf(item), 1);
            }
        }
        console.log(selectedFiles);
    });
});

//btn-select-images
$(document).on('click', '#btn-select-images', function () {
    renderImageList()
    $("#modalSelectFiles").hide();
});

//remove frome select imagelist
$(document).on('click', '#remove-from-list', function (e) {
    let path = $(this).attr("data-path");
    selectedFiles.splice(selectedFiles.indexOf(path), 1);
    renderImageList();
});

//render imageslist
function renderImageList() {
    let html = "";
    selectedFiles.map(item => {
        html += `<div class="col-span-5 md:col-span-2 h-28 relative image-fit cursor-pointer zoom-in">
                                                                   <img class="rounded-md" alt="${item}" src="${ftpRoot}${item}">
                                           <div title="Remove this image?" data-path="${item}" id="remove-from-list" class="tooltip w-5 h-5 flex items-center justify-center absolute rounded-full text-white bg-danger right-0 top-0 -mr-2 -mt-2">
                                           <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" icon-name="x" data-feather="x" class="lucide lucide-x w-4 h-4"><line x1="18" y1="6" x2="6" y2="18"></line><line x1="6" y1="6" x2="18" y2="18"></line></svg>
                                           </div>
                                       </div>`;
    });
    $('#box-selected-images').html(html);
}

//Go To Root
function goToRoot() {
    $("#filemanager-body").html(loading);
    $('#back-button').addClass("d-none");
    $('#remove-files').addClass("d-none");

    Directory = "";
    getDirectoryList();
    Directories = [""];
}

//Back To Last Directory
function backToLastDirectory() {
    $("#filemanager-body").html(loading);
    $('#remove-files').addClass("d-none");
    Directories.pop();
    if (Directories.length > 0) {
        Directory = Directories.reduce(function (a, b) {
            return a + b
        });
        if (Directories.length == 1) {
            $('#back-button').addClass("d-none");
        }
    }
    getDirectoryList();
}

//Open Folder
function openFile(path) {
    $("#filemanager-body").html(loading);
    $('#back-button').removeClass("d-none");
    $('#remove-files').addClass("d-none");

    Directories.push(path);
    Directory += path;
    getDirectoryList();
}


//get directory
function getDirectoryList() {
    var model = {
        Directory
    }
    if (selectMultiple) {
        $("#upload-modal-footer").html(`<button type="button" data-tw-dismiss="modal" class="btn btn-outline-secondary w-20 mr-1">لغو</button>
                         <button type="button" id="btn-select-images" class="btn btn-primary w-20">انتخاب</button>`);
    } else {
        $("#upload-modal-footer").html(`<button type="button" data-tw-dismiss="modal" class="btn btn-outline-secondary w-20 mr-1">لغو</button>`);
    }
    ajaxFunc(UrlGet, model, "POST",
        function (result) {
           
            if (result.isSuccess) {
                let html = "";
                if (result.data.length > 0) {
                  
                    result.data.map(item => {
                        html += `<div class="intro-y col-span-6 sm:col-span-4 md:col-span-3 2xl:col-span-2">
                                                   <div  class="file box rounded-md px-5 pt-8 pb-5 px-3 sm:px-5 relative zoom-in"> `;
                        if (item.fileTypeEnum == 0) {
                            html += `<div onclick="openFile('${item.directory}')"  class="w-3/5 file__icon file__icon--directory mx-auto"></div>`;
                           
                        }
                        else if (item.fileTypeEnum == 1) {
                            if (selectMultiple) {
                              
                                let isChecked = selectedFiles.includes(item.path) ? "checked" : "";
                                html+=`<div class="absolute left-0 top-0 mt-3 ml-3">
                                                                        <input data-path="${item.path}" ${isChecked} name="checkbox-file" class="form-check-input border border-slate-500 selected-image-multiple" type="checkbox">
                                                        </div>
                                                        <a href="#" class="w-3/5 file__icon file__icon--image mx-auto">
                                                             <div class="file__icon--image__preview image-fit">
                                                                 <img alt="${item.name}" src="${item.baseUrl}${item.path}">
                                                             </div>
                                                         </a>`;
                            }
                          
                            else {
                                html+=`<div onclick="selectImage('${item.path}','${selectorInput}')" class="w-3/5 file__icon file__icon--image mx-auto">
                                                             <div class="file__icon--image__preview image-fit">
                                                                 <img alt="${item.name}" src="${item.baseUrl}${item.path}">
                                                             </div>
                                                         </div>`;
                            }
                        }
                        else {
                            html+=`<a href="#" class="w-3/5 file__icon file__icon--file mx-auto">
                                                                                                        <div class="file__icon__file-name">${item.postfix}</div>
                                                                                                    </a>`;
                        }
                        html+= `<a href="" class="block font-medium mt-4 text-center truncate">${item.name}</a>
                                                   <div class="text-slate-500 text-xs text-center mt-0.5">${item.size}</div>
                                                         <div class="absolute top-0 right-0 mr-2 mt-3 dropdown ml-auto">
                                                             <a class="dropdown-toggle w-5 h-5 block" href="javascript:;" aria-expanded="false" data-tw-toggle="dropdown"> <i data-feather="more-vertical" class="w-5 h-5 text-slate-500"></i> </a>
                                                             <div class="dropdown-menu w-40">
                                                                 <ul class="dropdown-content">
                                                                     <li>
                                                                         <a href="" class="dropdown-item"> <i data-feather="users" class="w-4 h-4 mr-2"></i> Share File </a>
                                                                     </li>
                                                                     <li>
                                                                         <a href="" class="dropdown-item"> <i data-feather="trash" class="w-4 h-4 mr-2"></i> Delete </a>
                                                                     </li>
                                                                 </ul>
                                                             </div>
                                                         </div>
                                                     </div>
                                                 </div>`;
                    });
                } else {
                    html = `<div class="intro-y text-center col-span-12 sm:col-span-12 md:col-span-12 2xl:col-span-12">آیتمی جهت نمایش وجود ندارد</div>`;
                }
                $("#filemanager-body").html(html);
            } else {
                console.log("error load");
            }
        },
        function (error) {
            console.log(error);
        }
    );
}
let loading = `<div class="intro-y col-span-12 sm:col-span-12 md:col-span-12 2xl:col-span-12">
                <div class="col-span-6 sm:col-span-3 xl:col-span-2 flex flex-col justify-end items-center">
                    <svg width="25" viewBox="0 0 44 44" xmlns="http://www.w3.org/2000/svg" stroke="rgb(30, 41, 59)" class="w-8 h-8">
                        <g fill="none" fill-rule="evenodd" stroke-width="4">
                            <circle cx="22" cy="22" r="1">
                                <animate attributeName="r" begin="0s" dur="1.8s" values="1; 20" calcMode="spline" keyTimes="0; 1" keySplines="0.165, 0.84, 0.44, 1" repeatCount="indefinite"></animate>
                                <animate attributeName="stroke-opacity" begin="0s" dur="1.8s" values="1; 0" calcMode="spline" keyTimes="0; 1" keySplines="0.3, 0.61, 0.355, 1" repeatCount="indefinite"></animate>
                            </circle>
                            <circle cx="22" cy="22" r="1">
                                <animate attributeName="r" begin="-0.9s" dur="1.8s" values="1; 20" calcMode="spline" keyTimes="0; 1" keySplines="0.165, 0.84, 0.44, 1" repeatCount="indefinite"></animate>
                                <animate attributeName="stroke-opacity" begin="-0.9s" dur="1.8s" values="1; 0" calcMode="spline" keyTimes="0; 1" keySplines="0.3, 0.61, 0.355, 1" repeatCount="indefinite"></animate>
                            </circle>
                        </g>
                    </svg>
                    <div class="text-center text-xs mt-2">لطفا منتظر بمانید...</div>
                </div>
               </div>`;
