
function DivF() {
            var dd = document.createElement('div');
            dd.id ='dd';
            var main = document.getElementById('main');
            main.appendChild(dd);


            dd = document.getElementById('dd');
            dd.innerHTML = '<i>Misiunea</i><br/>Facultăţii de Matematică şi Informatică constă în promovarea programelor educaţionale şi de cercetare racordate la standarde internaţionale în domeniile matematicii şi tehnologiilor informaţionale, corelate cu cerinţele pieţei muncii din Republica Moldova.';
            dd.setAttribute('class', 'NC');
            dd.style.paddingLeft = '10px';
            dd.style.marginTop   = '3px';
            dd.style.visibility = 'hidden';
            dd.style.borderStyle = 'solid';
            dd.style.border.color = '#c0c0c0';
            dd.style.backgroundColor='#efefef';
            dd.style.borderWidth  = '1px';
            dd.style.position = 'relative';

            var q = document.getElementsByTagName("div");
            for (var i = 0; i < q.length; i++) {
                if (q[i].id != 'dd') {
                    q[i].style.width = (screen.width * 0.5).toString() + 'px';
                }
            }
        }

